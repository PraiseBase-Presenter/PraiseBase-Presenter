using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    class PowerPraiseSongFilePlugin : AbstractSongFilePlugin<PowerPraiseSong>
    {
        public PowerPraiseSongFilePlugin()
        {
            reader = new PowerPraiseSongFileReader();
            mapper = new PowerPraiseSongFileMapper();
        }
    }
}
