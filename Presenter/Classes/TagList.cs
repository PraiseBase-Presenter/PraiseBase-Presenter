using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp
{
    /// <summary>
    /// Tag class. It allows only unique items
    /// </summary>
    public class TagList : List<string>
    {
        /// <summary>
        /// Adds an unique tag to the taglist
        /// </summary>
        /// <param name="tagName"></param>
        public new void Add(string tagName)
        {
            if (!Contains(tagName))
            {
                base.Add(tagName);
            }
        }

        /// <summary>
        /// Returns a comma separated string of all tags
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res = string.Empty;
            for (int i = 0; i < Count; i++)
            {
                res += this.ElementAt(i);
                if (i < Count - 1)
                    res += ", ";
            }
            return res;
        }
    }
}
