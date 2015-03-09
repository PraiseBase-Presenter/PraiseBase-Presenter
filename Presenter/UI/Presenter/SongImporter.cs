using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Persistence.PraiseBox;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.UI.Presenter
{
    public partial class SongImporter : Form
    {
        private ImportFormat _format;

        private Settings settings;

        /// <summary>
        /// List of songs to be opened in the editor
        /// </summary>
        public List<string> OpenInEditor { get; private set; }

        /// <summary>
        /// Imports songs from other systems
        /// </summary>
        /// <param name="importFormat">Import type</param>
        public SongImporter(Settings settings, ImportFormat importFormat)
        {
            this.settings = settings;
            _format = importFormat;
            InitializeComponent();
        }

        private void PraiseBoxImporter_Load(object sender, EventArgs e)
        {
            switch (_format)
            {
                case ImportFormat.PraiseBox:
                    loadPraiseBoxFile();
                    break;
                case ImportFormat.WorshipSystem:
                    loadWorshipSystemFile();
                    break;
                default:
                    MessageBox.Show(Properties.StringResources.Sorry + "! " + Properties.StringResources.NoSongImporterAvailable, 
                        Properties.StringResources.SongImporter, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
            }
        }

        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                Song sng = ((Song)(listViewSongs.SelectedItems[0].Tag));

                listViewDetails.Items.Clear();
                foreach (SongPart prt in sng.Parts)
                {
                    foreach (SongSlide sld in prt.Slides)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { prt.Caption, sld.GetOneLineText() });
                        listViewDetails.Items.Add(lvi);
                    }
                }
                listViewDetails.Columns[0].Width = -2;
                listViewDetails.Columns[1].Width = -2;
            }
        }

        private void buttonSelAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                listViewSongs.Items[x].Checked = true;
            }
        }

        private void buttonDSelAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                listViewSongs.Items[x].Checked = false;
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            List<String> filesToOpen = new List<string>();
            int cnt = 0;
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                var item = listViewSongs.Items[x];
                if (item.Checked)
                {
                    Song sng = ((Song)listViewSongs.Items[x].Tag);

                    // Apply formatting
                    SongTemplateUtil.ApplyFormattingFromSettings(settings, sng);

                    // TODO: Allow selection of plugin
                    ISongFilePlugin filePlugin = SongFilePluginFactory.Create(SongFilePluginFactory.GetWriterPlugins().First().GetType());
                    string fileName = settings.DataDirectory + Path.DirectorySeparatorChar
                        + settings.SongDir + Path.DirectorySeparatorChar
                        + sng.Title + filePlugin.GetFileExtension();
                    if ((File.Exists(fileName) && (MessageBox.Show(string.Format(Properties.StringResources.SongExistsAlready, ((Song)listViewSongs.Items[x].Tag).Title) 
                        + " " + Properties.StringResources.Overwrite + "?", Properties.StringResources.SongImporter, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) || !File.Exists(fileName))
                    {
                        if (sng.Guid == Guid.Empty)
                        {
                            sng.Guid = Guid.NewGuid();
                        }
                        // TODO Exception handling
                        filePlugin.Save(sng, fileName);
                        filesToOpen.Add(fileName);
                        cnt++;
                    }
                }
            }
            if (cnt > 0)
            {
                MessageBox.Show(string.Format(Properties.StringResources.SongsImported, cnt.ToString()), Properties.StringResources.SongImporter, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (checkBoxUseEditor.Checked)
                {
                    for (int x = 0; x < listViewSongs.Items.Count; x++)
                    {
                        if (listViewSongs.Items[x].Checked)
                        {
                            OpenInEditor.Add(filesToOpen[x]);
                        }
                    }
                }

                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void loadPraiseBoxFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = Properties.StringResources.OpenPraiseBoxDatabase;
            dlg.Filter = Properties.StringResources.OpenPraiseBoxDatabase + " (*.pbd)|*.pbd|Alle Dateien (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String filename = dlg.FileName;
                ISongImporter importer = new PraiseBoxDatabaseImporter();
                try
                {
                    foreach (Song sng in importer.importFromFile(filename))
                    {
                        ListViewItem lvi = new ListViewItem(sng.Title);
                        lvi.Checked = true;
                        lvi.Tag = sng;
                        listViewSongs.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }
            
        private void loadWorshipSystemFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = Properties.StringResources.OpenWorshipSystemDatabase;
            dlg.Filter = Properties.StringResources.OpenWorshipSystemDatabase + " (*.mdb)|*.mdb|Alle Dateien (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String filename = dlg.FileName;
                ISongImporter importer = new WorshipSystemDatabaseImporter();
                try
                {
                    foreach (Song sng in importer.importFromFile(filename))
                    {
                        ListViewItem lvi = new ListViewItem(sng.Title);
                        lvi.Checked = true;
                        lvi.Tag = sng;
                        listViewSongs.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
            }
            else
            {
                this.Close();
            }

        }
    }
}