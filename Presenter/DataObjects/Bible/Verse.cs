using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Bible
{
    public class Verse
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public Chapter Chapter { get; set; }

        public Verse()
        {
        }

        public override string ToString()
        {
            return Number.ToString() + ": " + Text;
        }
    }
}
