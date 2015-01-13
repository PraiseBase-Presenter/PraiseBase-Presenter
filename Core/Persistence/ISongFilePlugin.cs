using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongFilePlugin
    {
        Song Load(String filePath);
        Boolean IsSupported(String filePath);
    }
}
