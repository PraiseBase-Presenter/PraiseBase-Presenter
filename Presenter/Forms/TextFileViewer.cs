using System;
using System.IO;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Forms
{
    public partial class TextFileViewer : Form
    {
        private string _filePath;

        public string FilePath {
            get {
                return _filePath;
            }
            set
            {
                _filePath = value;
                try
                {
                    using (FileStream logFileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(logFileStream))
                        {
                            string line = sr.ReadToEnd();
                            textBoxContent.Text = line;
                        }
                    }
                }
                catch (Exception e)
                {
                    textBoxContent.Text = "The file could not be read:" + e.Message;
                }
            }
        }

        public TextFileViewer()
        {
            InitializeComponent();
        }

        private void TextFileViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
