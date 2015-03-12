using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Controls
{
    [DefaultEvent("TextChanged")]
    public partial class SearchTextBox : UserControl
    {
        #region Delegates

        public delegate void TextChange(object sender, EventArgs e);

        #endregion Delegates

        private readonly PictureBox _cmPictureBox = new PictureBox();
        private ContextMenuStrip _contextMenu;

        private string _placeHolderText = "Suchen";
        private string _currentText = String.Empty;

        public SearchTextBox()
        {
            InitializeComponent();

            SuspendLayout();

            Paint += UserControl1_Paint;
            Resize += UserControl1_Resize;

            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.White;
            textBox.Font = new Font(textBox.Font.FontFamily, 10, FontStyle.Regular);
            textBox.Enter += textBox_Enter;
            textBox.Leave += textBox_Leave;
            textBox.Click += textBox_Click;
            textBox.KeyDown += textBox_KeyDown;
            textBox.TextChanged += textBox_TextChanged;

            EnabledChanged += SearchTextBox_EnabledChanged;

            xPictureBox.Image = PraiseBase.Presenter.Properties.Resources.searchx;
            xPictureBox.Click += xPictureBox_Click;
            xPictureBox.Visible = false;

            keyStrokeTimer.Interval = 250;
            keyStrokeTimer.Tick += keyStrokeTimer_Tick;

            _cmPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _cmPictureBox.Image = PraiseBase.Presenter.Properties.Resources.arrowdown;
            _cmPictureBox.Size = new Size(8, 8);
            _cmPictureBox.Location = new Point(19, 7);
            _cmPictureBox.MouseClick += cmPictureBox_MouseClick;
            _cmPictureBox.Visible = false;

            Controls.Add(textBox);
            Controls.Add(xPictureBox);
            Controls.Add(_cmPictureBox);

            ResumeLayout(false);

            textBox.ForeColor = Color.Gray;
            textBox.Text = _placeHolderText;
        }

        [Description("The placeholder is displayed when the field is empty and does not have the focus."),
         Category("SearchTextBox"), DefaultValue("Suchen"), Localizable(true)]
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                textBox.ForeColor = Color.Gray;
                textBox.Text = _placeHolderText;
            }
        }

        [Description("Assign a context menu to set search options"), Category("SearchTextBox")]
        public ContextMenuStrip OptionsMenu
        {
            get { return _contextMenu; }
            set
            {
                _contextMenu = value;
                _cmPictureBox.Visible = (value != null);
                UpdateTextBoxPosition();
            }
        }

        [Description("If greater than 0, waits this amount of miliseconds after a key has been pressed before raising the TextChanged event."), 
         Category("SearchTextBox"), DefaultValue(250)]
        public int KeyStrokeDelay
        {
            get { return keyStrokeTimer.Interval; }
            set { keyStrokeTimer.Interval = value; }
        }


        public new Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }

        public new string Text
        {
            get { return textBox.Text != _placeHolderText ? textBox.Text : String.Empty; }
            set
            {
                textBox.Text = value;
                textBox.ForeColor = Color.Black;
            }
        }

        public new event TextChange TextChanged;

        private void cmPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_contextMenu != null)
            {
                Point loc = Parent.PointToScreen(Location);
                _contextMenu.Show(loc.X + 3, loc.Y + Height);
            }
        }

        private void SearchTextBox_EnabledChanged(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                BackColor = Color.LightGray;
                textBox.BackColor = Color.LightGray;
            }
            else
            {
                BackColor = Color.White;
                textBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Occurs when the Text property value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (keyStrokeTimer.Enabled)
                keyStrokeTimer.Stop();
            if (textBox.Text == String.Empty || textBox.Text == _placeHolderText)
            {
                if (_currentText != textBox.Text && textBox.Text == String.Empty && TextChanged != null)
                {
                    _currentText = textBox.Text;
                    TextChanged(this, e);
                }
                xPictureBox.Visible = false;
            }
            else
            {
                xPictureBox.Visible = true;
                if (_currentText != textBox.Text)
                {
                    _currentText = textBox.Text;
                    keyStrokeTimer.Start();
                }
            }
        }

        private void keyStrokeTimer_Tick(object sender, EventArgs e)
        {
            if (textBox.Text != _placeHolderText && TextChanged != null)
                TextChanged(this, e);
            keyStrokeTimer.Stop();
        }

        private void xPictureBox_Click(object sender, EventArgs e)
        {
            textBox.Text = String.Empty;
            textBox.Focus();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox.Text = String.Empty;
            }
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (textBox.Text == _placeHolderText)
            {
                textBox.ForeColor = Color.Black;
                textBox.Text = string.Empty;
            }
            else
            {
                textBox.SelectAll();
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = _placeHolderText;
            }
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            UpdateTextBoxPosition();
            xPictureBox.Size = new Size(15, 15);
            xPictureBox.Location = new Point(Width - 18, (Height - 15) / 2);
        }

        private void UpdateTextBoxPosition()
        {
            int offset = _contextMenu != null ? 10 : 0;
            textBox.Size = new Size(Width - 43 - offset, Height - 6);
            textBox.Location = new Point(23 + offset, 4);
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(PraiseBase.Presenter.Properties.Resources.searchg, 3, (Height - 18) / 2, 18, 18);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        public void select(int start, int length)
        {
            textBox.Select(start, length);
        }

        private void SearchTextBox_Load(object sender, EventArgs e)
        {
        }
    }
}