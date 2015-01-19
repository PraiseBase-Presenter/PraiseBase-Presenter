using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface ISongFileMapper<T> where T : ISongFile
    {
        Song map(T source);

        void map(Song song, T target);
    }
}
