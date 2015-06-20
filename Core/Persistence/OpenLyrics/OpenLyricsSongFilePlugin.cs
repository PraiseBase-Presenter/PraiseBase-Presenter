namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongFilePlugin : AbstractSongFilePlugin<OpenLyricsSong>
    {
        public OpenLyricsSongFilePlugin()
        {
            Reader = new OpenLyricsSongFileReader();
            Mapper = new OpenLyricsSongFileMapper();
        }

        public override string GetFileExtension()
        {
            return ".xml";
        }

        public override string GetFileTypeDescription()
        {
            return "OpenLyrics Song";
        }
    }
}