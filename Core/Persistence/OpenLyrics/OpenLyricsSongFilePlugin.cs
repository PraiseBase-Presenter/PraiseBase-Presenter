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

        public override bool IsImportSupported()
        {
            return true;
        }

        public override int LoadingOrder()
        {
            return 3;
        }
    }
}