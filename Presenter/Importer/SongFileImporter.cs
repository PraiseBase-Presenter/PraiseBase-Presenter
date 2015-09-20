using PraiseBase.Presenter.Editor;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Persistence.CCLI;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Importer
{
    class SongFileImporter
    {
        /// <summary>
        /// Delegate to inform subscribers that a song has been saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SongSave(object sender, SongSavedEventArgs e);

        /// <summary>
        /// Song saved event
        /// </summary>
        public event SongSave SongSaved;

        Settings _settings;

        public SongFileImporter(Settings settings)
        {
            _settings = settings;
        }

        public void ImportDialog(IWin32Window owner)
        {
            string defaultDirectory = !string.IsNullOrEmpty(_settings.CurrentSongImporterDirectory) && Directory.Exists(_settings.CurrentSongImporterDirectory) ? _settings.CurrentSongImporterDirectory : _settings.DataDirectory;

            List<ISongFilePlugin> plugins = SongFilePluginFactory.GetImportPlugins();
            List<string> filters = new List<string>();
            foreach (ISongFilePlugin plugin in plugins)
            {
                filters.Add(string.Format("{0} (*{1})|*{1}", plugin.GetFileTypeDescription(), plugin.GetFileExtension()));
            }

            //var plugin = new SongSelectFilePlugin();
            var dlg = new OpenFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckFileExists = true,
                Filter = string.Join("|", filters.ToArray()),
                InitialDirectory = defaultDirectory,
                Title = StringResources.SongImporter,
                Multiselect = true
            };            
            if (dlg.ShowDialog(owner) == DialogResult.OK)
            {
                var plugin = plugins[dlg.FilterIndex - 1];

                SongTemplateMapper stm = new SongTemplateMapper(_settings);

                // Save selected directory
                if (dlg.FileNames.Length > 0)
                {
                    _settings.CurrentSongImporterDirectory = Path.GetDirectoryName(dlg.FileNames[0]);
                }

                int i = 0;
                foreach (var selectedFileName in dlg.FileNames)
                {
                    // Load song
                    var sng = plugin.Load(selectedFileName);

                    // Apply formatting
                    stm.ApplyFormattingFromSettings(sng);
                    // Apply default background
                    foreach (var p in sng.Parts)
                    {
                        foreach (var s in p.Slides)
                        {
                            if (s.Background == null)
                            {
                                s.Background = stm.GetDefaultBackground();
                            }
                        }
                    }

                    // Initialize writer
                    ISongFilePlugin filePlugin = SongFilePluginFactory.Create(SongFilePluginFactory.GetWriterPlugins().First().GetType());

                    // Define target file name
                    string fileName = _settings.DataDirectory + Path.DirectorySeparatorChar
                        + _settings.SongDir + Path.DirectorySeparatorChar
                        + sng.Title + filePlugin.GetFileExtension();

                    // Check if already exists
                    if ((File.Exists(fileName) && (MessageBox.Show(
                        string.Format(StringResources.SongExistsAlready,
                        sng.Title) + @" " + StringResources.Overwrite + @"?", StringResources.SongImporter,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) || !File.Exists(fileName))
                    {
                        // TODO Exception handling
                        filePlugin.Save(sng, fileName);

                        i++;

                        // Inform others by firing a SongSaved event
                        if (SongSaved != null)
                        {
                            SongSavedEventArgs p = new SongSavedEventArgs(sng, selectedFileName);
                            SongSaved(this, p);
                        }
                    }
                }

                MessageBox.Show(string.Format(StringResources.nSongsHaveBeenImported, i), StringResources.SongImporter, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
