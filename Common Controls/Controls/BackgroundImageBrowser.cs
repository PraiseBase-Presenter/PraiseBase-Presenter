using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Controls
{
    [DefaultEvent("ImageSelected")]
    public partial class BackgroundImageBrowser : UserControl
    {
        public delegate void imageSelect(object sender, BackgroundImageSelecteEventArgs e);

        public event imageSelect ImageSelected;

        private string _rootDirectory;

        public string RootDirectory
        {
            get { return _rootDirectory; }
            set
            {
                if (System.IO.Directory.Exists(value))
                {
                    _rootDirectory = value;
                    loadImages();
                }
            }
        }

        public Size ImageSize
        {
            get { return imList.ImageSize; }
            set
            {
                imList.ImageSize = value;
            }
        }

        public int NumberOfImages
        {
            get
            {
                return imList.Images.Count;
            }
        }

        private ImageList imList = new ImageList();
        private Dictionary<string, ImageList> savedImLists = new Dictionary<string, ImageList>();

        private int iw, ih;
        private int p = 5;
        private int numRows, imagesPerRow;

        public BackgroundImageBrowser()
        {
            InitializeComponent();
            this.AutoScroll = true;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            imList.ImageSize = new Size(80, 60);
            imList.ColorDepth = ColorDepth.Depth32Bit;

            iw = imList.ImageSize.Width;
            ih = imList.ImageSize.Height;
        }

        private void BackgrundImageBrowser_Load(object sender, EventArgs e)
        {
        }

        private Bitmap bImg;

        private void loadImages()
        {
            imList.Images.Clear();

            this.AutoScrollPosition = new Point(0, 0);

            if (System.IO.Directory.Exists(_rootDirectory))
            {
                if (savedImLists.ContainsKey(_rootDirectory))
                {
                    imList = savedImLists[_rootDirectory];
                }
                else
                {
                    string[] songFilePaths = System.IO.Directory.GetFiles(_rootDirectory, "*.jpg", System.IO.SearchOption.TopDirectoryOnly);
                    foreach (string file in songFilePaths)
                    {
                        FileInfo f = new FileInfo(file);
                        imList.Images.Add(f.Name, Image.FromFile(file));
                    }

                    //savedImLists.Add(_rootDirectory, );
                }

                PaintImages();
            }
        }

        //private Bitmap _backBuffer;

        private void PaintImages()
        {
            imagesPerRow = (int)Math.Floor((float)(this.Width - p) / (float)(iw + p));
            numRows = (int)Math.Ceiling((float)imList.Images.Count / (float)imagesPerRow);

            bImg = new Bitmap(this.Width, p + (numRows * (ih + p)));
            Graphics g = Graphics.FromImage(bImg);

            int w = this.Width;
            int h = this.Height;
            int x = p;
            int y = p + this.AutoScrollPosition.Y;

            for (int i = 0; i < imList.Images.Count; i++)
            {
                g.DrawImageUnscaled(imList.Images[i], x, y);

                x += iw + p;
                if (x >= w - p - iw)
                {
                    x = p;
                    y += ih + p;
                }
            }
            g.Dispose();
            pictureBox1.Image = bImg;
            pictureBox1.Size = bImg.Size;

            Console.WriteLine(pictureBox1.Size);

            /*

            //if (_backBuffer == null)
            //{
            _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Width);

            //}
            Graphics g = Graphics.FromImage(_backBuffer);

            g.Clear(Color.White);

            int w = this.Width;
            int h = this.Height;
            int x = p;
            int y = p + this.AutoScrollPosition.Y;

            for (int i = 0; i < imList.Images.Count; i++)
            {
                if (y >= -ih)
                {
                    g.DrawImageUnscaled(imList.Images[i], x, y);

                    //g.DrawImage(imList.Images[i], x, y,iw,ih);
                }

                //g.DrawRectangle(new Pen(Brushes.Black,3),new Rectangle(x,y,iw,ih));

                x += iw + p;
                if (x >= w - p - iw)
                {
                    x = p;
                    y += ih + p;
                }

                if (y - ih  > h )
                    break;
            }
            g.Dispose();

            //Copy the back buffer to the screen
            ge.DrawImageUnscaled(_backBuffer, 0, 0);
             */
        }

        private void BackgrundImageBrowser_Resize(object sender, EventArgs e)
        {
            PaintImages();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > p && e.X < (imagesPerRow) * (iw + p))
            {
                int f = (int)Math.Ceiling((imagesPerRow + 1) * (float)(e.X - p) / (float)this.Width);
                int g = (int)Math.Ceiling(numRows * (float)(e.Y - p - this.AutoScrollPosition.Y) / (float)(numRows * (ih + p)));
                int idx = f + ((g - 1) * (imagesPerRow)) - 1;

                //Console.WriteLine("### " + f + " " + g + "");
                if (idx < imList.Images.Count)
                {
                    if (ImageSelected != null)
                    {
                        BackgroundImageSelecteEventArgs ea = new BackgroundImageSelecteEventArgs(imList.Images.Keys[idx]);
                        ImageSelected(this, ea);
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > p && e.X < (imagesPerRow) * (iw + p))
            {
                int f = (int)Math.Ceiling((imagesPerRow + 1) * (float)(e.X - p) / (float)this.Width);
                int g = (int)Math.Ceiling(numRows * (float)(e.Y - p - this.AutoScrollPosition.Y) / (float)(numRows * (ih + p)));
                int idx = f + ((g - 1) * (imagesPerRow)) - 1;

                //Console.WriteLine("### " + f + " " + g + "");
                if (idx < imList.Images.Count)
                {
                    Cursor = Cursors.Hand;
                }
                else
                    Cursor = Cursors.Default;
            }
            else
                Cursor = Cursors.Default;
        }
    }

    public class BackgroundImageSelecteEventArgs : EventArgs
    {
        public BackgroundImageSelecteEventArgs(String imageName)
        {
            this.ImageName = imageName;
        }

        public String ImageName { get; set; }
    }
}