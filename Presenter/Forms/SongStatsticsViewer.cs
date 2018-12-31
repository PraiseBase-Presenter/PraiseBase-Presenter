using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence.Setlists;
using PraiseBase.Presenter.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static MoreLinq.Extensions.DistinctByExtension;

namespace PraiseBase.Presenter.Forms
{
    public partial class SongStatsticsViewer : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string _setlistDir;
        private SongManager _songManager;

        private int sortColumn = 0;

        public SongStatsticsViewer(SongManager songManager)
        {
            InitializeComponent();
            _songManager = songManager;
            _setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
        }

        private void SongStatsticsViewer_Load(object sender, EventArgs e)
        {
            var startTime = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            var endTime = DateTime.Now;

            dateTimePickerStart.Value = startTime;
            dateTimePickerEnd.Value = endTime;

            PopulateTable(_setlistDir, startTime, endTime);
        }

        private void PopulateTable(string setlistDir, DateTime startTime, DateTime endTime)
        {
            if (Directory.Exists(setlistDir))
            {
                listViewTable.Items.Clear();
                if (startTime <= endTime)
                {
                    Dictionary<string, SongStatisticsItem> entries = new Dictionary<string, SongStatisticsItem>();
                    var myFiles = Directory.GetFiles(setlistDir, "*." + SetlistWriter.FileExtension, SearchOption.AllDirectories);
                    foreach (string f in myFiles)
                    {
                        var fileWriteTime = File.GetLastWriteTime(f);
                        if (startTime < fileWriteTime && endTime > fileWriteTime)
                        {
                            foreach (Song s in ReadSetListFile(f).DistinctBy(item => item.Title))
                            {
                                if (entries.ContainsKey(s.Title))
                                {
                                    entries[s.Title].Count++;
                                    if (fileWriteTime > entries[s.Title].LastUsed)
                                    {
                                        entries[s.Title].LastUsed = fileWriteTime;
                                    }
                                }
                                else
                                {
                                    entries.Add(s.Title, new SongStatisticsItem() {
                                        Count = 1,
                                        LastUsed = fileWriteTime,
                                        CCLI = s.CcliIdentifier,
                                        Author = s.Authors.ToString()
                                    });
                                }
                            }
                        }
                    }

                    int numSongs = 0;
                    int numTotal = 0;
                    var keys = entries.Keys.ToList();
                    keys.Sort();
                    foreach (var key in keys)
                    {
                        var entry = entries[key];
                        ListViewItem listitem = new ListViewItem(key);
                        listitem.SubItems.Add(entry.Author);
                        listitem.SubItems.Add(entry.CCLI);
                        listitem.SubItems.Add(entry.Count.ToString());
                        listitem.SubItems.Add(entry.LastUsed.ToString("d"));
                        listViewTable.Items.Add(listitem);
                        numSongs++;
                        numTotal += entry.Count;
                    }

                    toolStripStatusLabelSongs.Text = string.Format(StringResources.SongsCount, numSongs);
                    toolStripStatusLabelTimeRange.Text = string.Format(StringResources.TimeRangeFromTo, startTime.ToString("d"), endTime.ToString("d"));
                }
                else
                {
                    toolStripStatusLabelSongs.Text = string.Format(StringResources.SongsCount, 0);
                    toolStripStatusLabelTimeRange.Text = string.Format(StringResources.InvalidTimeRange);
                }
            }
        }

        private List<Song> ReadSetListFile(string fileName)
        {
            List<Song> list = new List<Song>();
            SetlistReader sr = new SetlistReader();
            try
            {
                Setlist sl = sr.read(fileName);
                if (sl.Items.Count > 0)
                {
                    foreach (var i in sl.Items)
                    {
                        var key = _songManager.GetKeyByTitle(i);
                        if (key != null)
                        {
                            var s = _songManager.SongList[key].Song;
                            list.Add(s);
                        }
                        else
                        {
                            list.Add(new Song() {
                                Title = i
                            });
                            log.WarnFormat("Song '{0}' from setlist '{1}' not found in song manager", i, fileName);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                log.ErrorFormat("Unable to read setlist file {0}: {1}", fileName, err.Message);
            }
            return list;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            PopulateTable(_setlistDir, dateTimePickerStart.Value, dateTimePickerEnd.Value);
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            PopulateTable(_setlistDir, dateTimePickerStart.Value, dateTimePickerEnd.Value);
        }

        private void listViewTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var selectedSong = lv.SelectedItems[0].Text;
                Clipboard.SetText(selectedSong);
                ShowNotification(string.Format(StringResources.CopiedIntoClipBoard, selectedSong));
            }
        }

        private void ShowNotification(string text)
        {
            timerNotification.Stop();
            toolStripStatusLabelNotification.Text = text;
            timerNotification.Start();
        }

        private void timerNotification_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelNotification.Text = string.Empty;
            timerNotification.Stop();
        }

        private void listViewTable_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listViewTable.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listViewTable.Sorting == SortOrder.Ascending)
                    listViewTable.Sorting = SortOrder.Descending;
                else
                    listViewTable.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listViewTable.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            if (e.Column == 4)
            {
                listViewTable.ListViewItemSorter = new ListViewDateItemComparer(e.Column, listViewTable.Sorting);
            }
            else
            {
                listViewTable.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewTable.Sorting);
            }
        }
    }

    class SongStatisticsItem
    {
        public string Author { get; set; }
        public string CCLI { get; set; }
        public int Count { get; set; }
        public DateTime LastUsed { get; set; }
    }

    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }

    class ListViewDateItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewDateItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewDateItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal;
            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare
            // as a string.
            catch
            {
                // Compare the two items as a string.
                returnVal = string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}
