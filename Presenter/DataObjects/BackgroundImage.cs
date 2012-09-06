using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Pbp
{
    class BackgroundImage : BackgroundElement
    {
        private string filePath;

        public BackgroundImage(string path)
        {
            this.filePath = path;

        }

        public string toString()
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

    }
}
