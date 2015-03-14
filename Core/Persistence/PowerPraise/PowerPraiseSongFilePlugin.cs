namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongFilePlugin : AbstractSongFilePlugin<PowerPraiseSong>
    {
        public PowerPraiseSongFilePlugin()
        {
            reader = new PowerPraiseSongFileReader();
            mapper = new PowerPraiseSongFileMapper();
            writer = new PowerPraiseSongFileWriter();
        }

        public override string GetFileExtension()
        {
            return ".ppl";
        }

        public override string GetFileTypeDescription()
        {
            return "PowerPraise Lied";
        }
    }
}