using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class ExtendedPowerPraiseSongFilePlugin : AbstractSongFilePlugin<ExtendedPowerPraiseSong>
    {
        public ExtendedPowerPraiseSongFilePlugin() : base()
        {
            reader = new ExtendedPowerPraiseSongFileReader();
            mapper = new ExtendedPowerPraiseSongFileMapper();
        }
    }
}
