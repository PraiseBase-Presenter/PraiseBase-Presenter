using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Pbp.Forms
{
    public partial class EditorChild : Form
    {
        XmlDocument xmlDoc;
        XmlElement xmlRoot;

        public EditorChild(string fileName)
        {
            if (fileName != null)
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                xmlRoot = xmlDoc.DocumentElement;

                string _title = xmlRoot["general"]["title"].InnerText;

                this.Text = _title;


                treeViewContents.Nodes.Add("asd");

            }
            InitializeComponent();
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {

        }
    }
}
