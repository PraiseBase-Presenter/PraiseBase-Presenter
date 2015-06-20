using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Persistence.PraiseBox;
using PraiseBase.Presenter.Persistence.WorshipSystem;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;

namespace PraiseBase.Presenter.Importer
{
    public partial class SongImporter : Form
    {
        private readonly ImportFormat _format;

        private readonly Settings _settings;

        /// <summary>
        /// List of songs to be opened in the editor
        /// </summary>
        public List<string> OpenInEditor { get; private set; }

        /// <summary>
        /// Imports songs from other systems
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="importFormat">Import type</param>
        public SongImporter(Settings settings, ImportFormat importFormat)
        {
            _settings = settings;
            _format = importFormat;
            OpenInEditor = new List<string>();
            InitializeComponent();
        }

        private void PraiseBoxImporter_Load(object sender, EventArgs e)
        {
            switch (_format)
            {
                case ImportFormat.PraiseBox:
                    LoadPraiseBoxFile();
                    break;
                case ImportFormat.WorshipSystem:
                    LoadWorshipSystemFile();
                    break;
                default:
                    MessageBox.Show(StringResources.Sorry + "! " + StringResources.NoSongImporterAvailable, 
                        StringResources.SongImporter, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
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
                        ListViewItem lvi = new ListViewItem(new[] { prt.Caption, sld.GetOneLineText() });
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
            SongTemplateMapper stm = new SongTemplateMapper(_settings);

            List<String> filesToOpen = new List<string>();
            int cnt = 0;
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                var item = listViewSongs.Items[x];
                if (item.Checked)
                {
                    Song sng = ((Song)listViewSongs.Items[x].Tag);

                    // Apply formatting
                    stm.ApplyFormattingFromSettings(sng);

                    // TODO: Allow selection of plugin
                    ISongFilePlugin filePlugin = SongFilePluginFactory.Create(SongFilePluginFactory.GetWriterPlugins().First().GetType());
                    string fileName = _settings.DataDirectory + Path.DirectorySeparatorChar
                        + _settings.SongDir + Path.DirectorySeparatorChar
                        + sng.Title + filePlugin.GetFileExtension();
                    if ((File.Exists(fileName) && (MessageBox.Show(
                        string.Format(StringResources.SongExistsAlready, 
                        ((Song)listViewSongs.Items[x].Tag).Title) + @" " + StringResources.Overwrite + @"?", StringResources.SongImporter, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) || !File.Exists(fileName))
                    {
                        // TODO Exception handling
                        filePlugin.Save(sng, fileName);
                        filesToOpen.Add(fileName);
                        cnt++;
                    }
                }
            }
            if (cnt > 0)
            {
                MessageBox.Show(string.Format(StringResources.SongsImported, cnt), StringResources.SongImporter, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (checkBoxUseEditor.Checked)
                {
                    foreach (var f in filesToOpen)
                    {
                        OpenInEditor.Add(f);
                    }
                }

                DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void LoadPraiseBoxFile()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Title = StringResources.OpenPraiseBoxDatabase,
                Filter = StringResources.OpenPraiseBoxDatabase + @" (*.pbd)|*.pbd|" + StringResources.AllFiles + @" (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String filename = dlg.FileName;
                ISongImporter importer = new PraiseBoxDatabaseImporter();
                try
                {
                    foreach (Song sng in importer.ImportFromFile(filename))
                    {
                        ListViewItem lvi = new ListViewItem(sng.Title)
                        {
                            Checked = true,
                            Tag = sng
                        };
                        listViewSongs.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(StringResources.Sorry + "! " + ex.Message, StringResources.DatabaseError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
            
        private void LoadWorshipSystemFile()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Title = StringResources.OpenWorshipSystemDatabase,
                Filter = StringResources.OpenWorshipSystemDatabase + @" (*.mdb)|*.mdb|" + StringResources.AllFiles + @" (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String filename = dlg.FileName;
                ISongImporter importer = new WorshipSystemDatabaseImporter();
                try
                {
                    foreach (Song sng in importer.ImportFromFile(filename))
                    {
                        ListViewItem lvi = new ListViewItem(sng.Title)
                        {
                            Checked = true,
                            Tag = sng
                        };
                        listViewSongs.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(StringResources.Sorry + "! " + ex.Message, StringResources.DatabaseError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                Close();
            }

        }
    }
}