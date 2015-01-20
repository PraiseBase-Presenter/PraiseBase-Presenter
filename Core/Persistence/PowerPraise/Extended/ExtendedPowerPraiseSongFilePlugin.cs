using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSongFilePlugin : AbstractSongFilePlugin<ExtendedPowerPraiseSong>
    {
        public ExtendedPowerPraiseSongFilePlugin() : base()
        {
            reader = new ExtendedPowerPraiseSongFileReader();
            mapper = new ExtendedPowerPraiseSongFileMapper();
            writer = new ExtendedPowerPraiseSongFileWriter();
        }

        public override string GetFileExtension() { return ".ppl"; }

        public override string GetFileTypeDescription() { return "PowerPraise Lied (erweitert)"; }
    }
}
