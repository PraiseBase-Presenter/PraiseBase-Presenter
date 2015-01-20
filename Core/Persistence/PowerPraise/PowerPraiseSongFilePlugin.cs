using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongFilePlugin : AbstractSongFilePlugin<PowerPraiseSong>
    {
        public PowerPraiseSongFilePlugin() : base()
        {
            reader = new PowerPraiseSongFileReader();
            mapper = new PowerPraiseSongFileMapper();
            writer = new PowerPraiseSongFileWriter();
        }

        public override string GetFileExtension() { return ".ppl"; }

        public override string GetFileTypeDescription() { return "PowerPraise Lied"; }
    }
}
