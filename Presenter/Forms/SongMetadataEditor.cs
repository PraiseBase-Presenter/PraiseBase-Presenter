using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class SongMetadataEditor : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string _setlistDir;
        private SongManager _songManager;

        public SongMetadataEditor(SongManager songManager)
        {
            InitializeComponent();
            _songManager = songManager;
            _setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
        }

        private void SongStatsticsViewer_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var s in _songManager.SongList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Tag = s.Key;
                row.Cells[0].Value = s.Value.Song.Title;
                row.Cells[1].Value = s.Value.Song.Authors.ToString();
                row.Cells[2].Value = s.Value.Song.CcliIdentifier;
                row.Cells[3].Value = s.Value.Song.Copyright;
                row.Cells[4].Value = s.Value.Song.SongBooks.ToString();
                row.Cells[5].Value = s.Value.Song.Publisher;
                row.Cells[6].Value = s.Value.Song.RightsManagement;
                dataGridView1.Rows.Add(row);
                i++;
            }
            toolStripStatusLabelSongs.Text = string.Format(StringResources.SongsCount, i);
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var key = (string)row.Tag;
            var s = _songManager.SongList[key];

            s.Song.Title = row.Cells[0].Value?.ToString();
            s.Song.Authors.FromString(row.Cells[1].Value?.ToString());
            s.Song.CcliIdentifier = row.Cells[2].Value?.ToString();
            s.Song.Copyright = row.Cells[3].Value?.ToString();
            s.Song.SongBooks.FromString(row.Cells[4].Value?.ToString());
            s.Song.Publisher = row.Cells[5].Value?.ToString();
            s.Song.RightsManagement = row.Cells[6].Value?.ToString();

            _songManager.SaveSong(key);
            ShowNotification(string.Format(StringResources.SongHasBeenUpdated, s.Song.Title));
        }
    }
}
