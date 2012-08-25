using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Bible
{
    public class Book
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public Bible Bible { get; set; }

        public List<Chapter> Chapters { get; set; }

        public Book()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
