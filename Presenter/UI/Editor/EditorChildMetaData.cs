using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.UI.Editor
{
    public class EditorChildMetaData
    {
        public string Filename { get; set; }
        public int HashCode { get; set; }

        public EditorChildMetaData(string filename, int hashCode)
        {
            Filename = filename;
            HashCode = hashCode;
        }
    }
}
