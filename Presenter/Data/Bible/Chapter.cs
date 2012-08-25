using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Bible
{
    public class Chapter
    {
        public int Number { get; set; }

        public Book Book { get; set; }

        public List<Verse> Verses { get; set; }
        
        public Chapter()
        {
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
