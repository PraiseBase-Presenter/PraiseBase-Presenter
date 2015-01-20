using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongFilePlugin : AbstractSongFilePlugin<OpenLyricsSong>
    {
        public OpenLyricsSongFilePlugin() : base()
        {
            reader = new OpenLyricsSongFileReader();
            mapper = new OpenLyricsSongFileMapper();
        }

        public override string GetFileExtension() { return ".xml"; }

        public override string GetFileTypeDescription() { return "OpenLyrics Song"; }
    }
}
