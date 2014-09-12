using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence
{
    public interface SongFileMapper<T>
    {
        Song map(T source);

        void map(Song song, T target);
    }
}
