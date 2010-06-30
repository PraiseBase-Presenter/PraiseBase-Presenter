namespace Pbp.Components
{
    partial class SearchTextBox
    {
        System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
        System.Windows.Forms.PictureBox xPictureBox = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.Timer keyStrokeTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.Name = "SearchTextBox";
            this.Paint += new System.Windows.Forms.PaintEventHandler(UserControl1_Paint);
            this.Resize += new System.EventHandler(UserControl1_Resize);

            textBox.Multiline = true;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Font = new System.Drawing.Font(textBox.Font.FontFamily, 10, System.Drawing.FontStyle.Regular);
            textBox.Enter += new System.EventHandler(textBox_Enter);
            textBox.Leave += new System.EventHandler(textBox_Leave);
            textBox.Click += new System.EventHandler(textBox_Click);
            textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_KeyDown);
            textBox.TextChanged += new System.EventHandler(textBox_TextChanged);

            xPictureBox.Image = Properties.Resources.searchx;
            xPictureBox.Click += new System.EventHandler(xPictureBox_Click);
            xPictureBox.Visible = false;

            keyStrokeTimer.Interval = 250;
            keyStrokeTimer.Tick += new System.EventHandler(keyStrokeTimer_Tick);          

            this.Controls.Add(textBox);
            this.Controls.Add(xPictureBox);

            this.ResumeLayout(false);
        }


        #endregion
    }
}
