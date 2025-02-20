using System.Drawing;
using System.Windows.Forms;

namespace PraiseBase.Presenter
{
    public sealed class MenuRenderer : ToolStripProfessionalRenderer
    {
        public MenuRenderer() : base(new MoonColors())
        {

        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.TextColor = Color.GhostWhite;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
            {
                // Assuming you want to draw a custom separator line:
                using (Pen separatorPen = new Pen(Color.DimGray, 1)) // Adjust color and width as needed
                {
                    e.Graphics.DrawLine(separatorPen, e.Item.Bounds.Left, e.Item.Bounds.Bottom - 1, e.Item.Bounds.Right, e.Item.Bounds.Bottom - 1);
                }
            }
            base.OnRenderSeparator(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.ArrowColor = Color.DimGray;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(Brushes.DimGray, rectangle);
                e.Graphics.DrawRectangle(Pens.White, rectangle);
            }
        }
    }

    public class MoonColors : ProfessionalColorTable
    {
        public override Color SeparatorLight
        {
            get { return Color.DimGray; }
        }

        public override Color SeparatorDark
        {
            get { return Color.DimGray; }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(30, 32, 36);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(30, 32, 36);
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(30, 32, 36);
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(30, 32, 36);
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return Color.FromArgb(30, 32, 36);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(255, 255, 255);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(24, 52, 75);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(24, 52, 75);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(24, 52, 75);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(255, 255, 255);
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(30, 32, 36); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(30, 32, 36); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(30, 32, 36); }
        }

        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(30, 32, 36); }
        }
        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(30, 32, 36); }
        }
    }
}
