using System;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSongFilePlugin : AbstractSongFilePlugin<ExtendedPowerPraiseSong>
    {
        public ExtendedPowerPraiseSongFilePlugin()
        {
            Reader = new ExtendedPowerPraiseSongFileReader();
            Mapper = new ExtendedPowerPraiseSongFileMapper();
            Writer = new ExtendedPowerPraiseSongFileWriter();
        }

        public override string GetFileExtension()
        {
            return ".ppl";
        }

        public override string GetFileTypeDescription()
        {
            return "PowerPraise Lied (erweitert)";
        }

        public override int LoadingOrder()
        {
            return 0;
        }
    }
}