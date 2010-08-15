﻿using System;
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
        private string _placeHolderText = "Suchen";
        [Description("The placeholder is displayed when the field is empty and does not have the focus."), Category("SearchTextBox"), DefaultValue("Suchen")]
        public string PlaceHolderText { 
            get { 
                return _placeHolderText; 
            } 
            set { 
                _placeHolderText = value;
                textBox.ForeColor = Color.Gray;
                textBox.Text = _placeHolderText;
            } 
        } 

        public new Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }

        public new string Text
        {
            get
            {
                return textBox.Text != _placeHolderText ? textBox.Text : String.Empty;
            }
            set
            {
                textBox.Text = value;
                textBox.ForeColor = Color.Black;
            }
        }

        [Description("If greater than 0, waits this amount of miliseconds after a key has been pressed before raising the TextChanged event."), Category("SearchTextBox"), DefaultValue(250)]
        public int KeyStrokeDelay { 
            get { return keyStrokeTimer.Interval; } 
            set { keyStrokeTimer.Interval = value;  } }

        public delegate void textChange(object sender, EventArgs e);
        public new event textChange TextChanged;

        private string currentText = String.Empty;

        public SearchTextBox()
        {
            InitializeComponent();

            SuspendLayout();

            this.Paint += new System.Windows.Forms.PaintEventHandler(UserControl1_Paint);
            this.Resize += new System.EventHandler(UserControl1_Resize);

            textBox.Multiline = true;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.BackColor = Color.White;
            textBox.Font = new System.Drawing.Font(textBox.Font.FontFamily, 10, System.Drawing.FontStyle.Regular);
            textBox.Enter += new System.EventHandler(textBox_Enter);
            textBox.Leave += new System.EventHandler(textBox_Leave);
            textBox.Click += new System.EventHandler(textBox_Click);
            textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_KeyDown);
            textBox.TextChanged += new System.EventHandler(textBox_TextChanged);

            this.EnabledChanged += new EventHandler(SearchTextBox_EnabledChanged);

            xPictureBox.Image = Properties.Resources.searchx;
            xPictureBox.Click += new System.EventHandler(xPictureBox_Click);
            xPictureBox.Visible = false;

            keyStrokeTimer.Interval = 250;
            keyStrokeTimer.Tick += new System.EventHandler(keyStrokeTimer_Tick);

            this.Controls.Add(textBox);
            this.Controls.Add(xPictureBox);
            
            ResumeLayout(false);

            textBox.ForeColor = Color.Gray;
            textBox.Text = _placeHolderText;
        }

        void SearchTextBox_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled)
            {
                this.BackColor = Color.LightGray;
                textBox.BackColor = Color.LightGray;
            }
            else
            {
                this.BackColor = Color.White;
                textBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Occurs when the Text property value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_TextChanged(object sender, EventArgs e)
        {
            if (keyStrokeTimer.Enabled)
                keyStrokeTimer.Stop();
            if (textBox.Text == String.Empty || textBox.Text == _placeHolderText)
            {
                if (currentText != textBox.Text && textBox.Text == String.Empty && TextChanged != null)
                {
                    currentText = textBox.Text;
                    TextChanged(this, e);
                }
                xPictureBox.Visible = false;
            }
            else
            {
                xPictureBox.Visible = true;
                if (currentText != textBox.Text)
                {
                    currentText = textBox.Text;
                    keyStrokeTimer.Start();
                }
            }
        }

        void keyStrokeTimer_Tick(object sender, EventArgs e)
        {
            if (textBox.Text != _placeHolderText && TextChanged != null)
                TextChanged(this, e);
            keyStrokeTimer.Stop();
        }


        void xPictureBox_Click(object sender, EventArgs e)
        {
            textBox.Text = String.Empty;
            textBox.Focus();
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

        void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = _placeHolderText;
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

        public void select(int start, int length)
        {
            textBox.Select(start, length);
        }

    }
}