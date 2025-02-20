using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PraiseBase.Presenter.Controls
{
    public partial class CustomGroupBox : Panel
    {
        private Color gradientStartColor = Color.LightBlue;
        private Color gradientEndColor = Color.DarkBlue;
        private float gradientAngle = 0.0f;

        [Description("Title of the groupbox"), Category("CustomGroupBox"), DefaultValue("Title"), Localizable(true)]
        public String Title
        {
            get
            {
                return labelTitle.Text;
            }
            set
            {
                labelTitle.Text = value;
            }
        }

        [Description("Start color of the gradient"), Category("CustomGroupBox"), DefaultValue(typeof(Color), "LightBlue")]
        public Color GradientStartColor
        {
            get { return gradientStartColor; }
            set
            {
                gradientStartColor = value;
                Invalidate();
            }
        }

        [Description("End color of the gradient"), Category("CustomGroupBox"), DefaultValue(typeof(Color), "DarkBlue")]
        public Color GradientEndColor
        {
            get { return gradientEndColor; }
            set
            {
                gradientEndColor = value;
                Invalidate();
            }
        }

        [Description("Angle of the gradient"), Category("CustomGroupBox"), DefaultValue(0.0f)]
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                Invalidate();
            }
        }

        public CustomGroupBox()
        {
            InitializeComponent();

            this.Padding = new Padding(3, 30, 3, 3);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, 28),
                gradientStartColor,
                gradientEndColor))
            {
                Rectangle gradientRect = new Rectangle(0, 0, Width, 28);
                e.Graphics.FillRectangle(brush, gradientRect);
            }
            DrawTitle(e.Graphics);
            base.OnPaint(e);
        }

        private void DrawTitle(Graphics g)
        {
            TextRenderer.DrawText(g, Title, Font, new Point(5, 5), ForeColor);
        }

        private void CustomGroupBox_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}