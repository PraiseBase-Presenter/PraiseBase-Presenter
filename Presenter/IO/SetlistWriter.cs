using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Pbp
{
    class SetlistWriter
    {
        public void write(string filename, Setlist list)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", ""));
            xmlDoc.AppendChild(xmlDoc.CreateElement("setlist"));
            XmlElement xmlRoot = xmlDoc.DocumentElement;
            xmlRoot.AppendChild(xmlDoc.CreateElement("items"));
            for (int i = 0; i < list.Items.Count; i++)
            {
                XmlNode nd = xmlDoc.CreateElement("item");
                nd.InnerText = list.Items[i].Title;
                XmlNode ni = xmlRoot["items"].AppendChild(nd);
            }
            XmlWriterSettings wrtStn = new XmlWriterSettings();
            wrtStn.Encoding = Encoding.UTF8;
            wrtStn.Indent = true;
            XmlWriter wrt = XmlTextWriter.Create(filename, wrtStn);
            xmlDoc.WriteTo(wrt);
            wrt.Flush();
            wrt.Close();
        }
    }
}
