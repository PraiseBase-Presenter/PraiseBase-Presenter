using System;
using System.Collections.Generic;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongImporter
    {
        List<Song> ImportFromFile(String path);
    }
}
