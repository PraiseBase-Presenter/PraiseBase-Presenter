using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Pbp
{
    class SetlistReader
    {
        public Setlist read(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "setlist")
            {
                throw new Exception("Ungültige Setlist!");
            }
            Setlist sl = new Setlist();
            if (xmlRoot["items"] != null)
            {
                sl.Items.Clear();
                for (int i = 0; i < xmlRoot["items"].ChildNodes.Count; i++)
                {
                    if (xmlRoot["items"].ChildNodes[i].Name == "item")
                    {
                        Guid g = SongManager.Instance.getGuidByTitle(xmlRoot["items"].ChildNodes[i].InnerText);
                        if (g != Guid.Empty)
                        {
                            sl.Items.Add(SongManager.Instance.SongList[g].Song);
                        }
                    }
                }
            }
            return sl;
        }
    }
}
