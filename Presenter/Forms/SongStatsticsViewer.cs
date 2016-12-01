using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence.Setlists;
using PraiseBase.Presenter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class SongStatsticsViewer : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string _setlistDir;
        private SongManager _songManager;

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
                            foreach (Song s in ReadSetListFile(f))
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
    }

    class SongStatisticsItem
    {
        public string Author { get; set; }
        public string CCLI { get; set; }
        public int Count { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
