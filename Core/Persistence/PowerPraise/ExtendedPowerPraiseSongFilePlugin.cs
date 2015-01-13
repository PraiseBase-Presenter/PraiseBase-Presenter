using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    class ExtendedPowerPraiseSongFilePlugin : AbstractSongFilePlugin<ExtendedPowerPraiseSong>
    {
        public ExtendedPowerPraiseSongFilePlugin()
        {
            reader = new ExtendedPowerPraiseSongFileReader();
            mapper = new ExtendedPowerPraiseSongFileMapper();
        }
    }
}
