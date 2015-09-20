namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongFilePlugin : AbstractSongFilePlugin<PowerPraiseSong>
    {
        public PowerPraiseSongFilePlugin()
        {
            Reader = new PowerPraiseSongFileReader();
            Mapper = new PowerPraiseSongFileMapper();
            Writer = new PowerPraiseSongFileWriter();
        }

        public override string GetFileExtension()
        {
            return ".ppl";
        }

        public override string GetFileTypeDescription()
        {
            return "PowerPraise Lied";
        }

        public override bool IsImportSupported()
        {
            return false;
        }

        public override int LoadingOrder()
        {
            return 1;
        }
    }
}