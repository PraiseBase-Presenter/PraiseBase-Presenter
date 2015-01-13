using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongFilePlugin : AbstractSongFilePlugin<OpenLyricsSong>
    {
        public OpenLyricsSongFilePlugin()
        {
            reader = new OpenLyricsSongFileReader();
            mapper = new OpenLyricsSongFileMapper();
        }
    }
}
