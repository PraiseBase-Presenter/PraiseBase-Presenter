using PraiseBase.Presenter.Editor;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Persistence.CCLI;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;
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

            var plugin = new SongSelectFilePlugin();
            var dlg = new OpenFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckFileExists = true,
                Filter = string.Format("{0} (*{1})|*{1}", plugin.GetFileTypeDescription(), plugin.GetFileExtension()),
                InitialDirectory = defaultDirectory,
                Title = StringResources.OpenSetlist
            };            
            if (dlg.ShowDialog(owner) == DialogResult.OK)
            {
                _settings.CurrentSongImporterDirectory = Path.GetDirectoryName(dlg.FileName);

                var sng = plugin.Load(dlg.FileName);

                SongTemplateMapper stm = new SongTemplateMapper(_settings);

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

                ISongFilePlugin filePlugin = SongFilePluginFactory.Create(SongFilePluginFactory.GetWriterPlugins().First().GetType());
                string fileName = _settings.DataDirectory + Path.DirectorySeparatorChar
                    + _settings.SongDir + Path.DirectorySeparatorChar
                    + sng.Title + filePlugin.GetFileExtension();
                if ((File.Exists(fileName) && (MessageBox.Show(
                    string.Format(StringResources.SongExistsAlready,
                    sng.Title) + @" " + StringResources.Overwrite + @"?", StringResources.SongImporter,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) || !File.Exists(fileName))
                {
                    // TODO Exception handling
                    filePlugin.Save(sng, fileName);

                    // Inform others by firing a SongSaved event
                    if (SongSaved != null)
                    {
                        SongSavedEventArgs p = new SongSavedEventArgs(sng, dlg.FileName);
                        SongSaved(this, p);
                    }
                }
            }
        }
    }
}
