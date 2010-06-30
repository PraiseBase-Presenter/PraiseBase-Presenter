using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pbp.Components
{
    [DefaultEvent("TextChanged")]
    public partial class SearchTextBox : UserControl
    {
        public string Text
        {
            get { return textBox.Text!="Lied suchen" ? textBox.Text : String.Empty; }
            set
            {
                if (value == string.Empty)
                {
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = "Lied suchen";
                }
                else
                {
                    textBox.ForeColor = Color.Black;
                    textBox.Text = value; 
                }
            }
        }

        public Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }

        public delegate void textChange(object sender, EventArgs e);
        public event textChange TextChanged;
 
        TextBox textBox = new TextBox();
        PictureBox xPictureBox = new PictureBox();

        public SearchTextBox()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(UserControl1_Paint);
            this.Resize += new EventHandler(UserControl1_Resize);
            textBox.Multiline = true;
            textBox.Font = new Font(textBox.Font.FontFamily,10,FontStyle.Regular);
            
            textBox.ForeColor = Color.Gray;
            textBox.Text = "Lied suchen";
            textBox.Enter += new EventHandler(textBox_Enter);
            textBox.Leave += new EventHandler(textBox_Leave);
            textBox.Click += new EventHandler(textBox_Click);
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textBox.TextChanged += new EventHandler(textBox_TextChanged);

            textBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(textBox);

            xPictureBox.Image = Properties.Resources.searchx;
            xPictureBox.Click += new EventHandler(xPictureBox_Click);
            xPictureBox.Visible = false;
            this.Controls.Add(xPictureBox);
        }

        /// <summary>
        /// Occurs when the Text property value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text == String.Empty || textBox.Text=="Lied suchen")
                xPictureBox.Visible = false;
            else
                xPictureBox.Visible = true;


            if (textBox.Text!="Lied suchen" && TextChanged != null)
                TextChanged(this, e);
        }

        void xPictureBox_Click(object sender, EventArgs e)
        {
            textBox.Text = String.Empty;
        }

        void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox.Text = String.Empty;
            }
        } 

        void textBox_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            if (textBox.Text == "Lied suchen")
            {
                textBox.ForeColor = Color.Black;
                textBox.Text = string.Empty;
            }
            else
            {
                textBox.SelectAll();
            }
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = "Lied suchen";
            }
        }
 
        private void UserControl1_Resize(object sender, EventArgs e)
        {
            textBox.Size = new Size(this.Width - 43, this.Height - 6);
            textBox.Location = new Point(23, 4);
            xPictureBox.Size = new Size(15,15);
            xPictureBox.Location = new Point(this.Width - 18, (this.Height - 15) / 2);
         }
 
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.searchg, 3, (this.Height - 18) / 2, 18, 18);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
         }

        private void SearchTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
