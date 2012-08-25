using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp
{
    public class Setlist
    {
        public String Name { get; set; }
        public List<Song> Items { get; set; }

        public Setlist()
        {
            Items = new List<Song>();
        }
    }
}
