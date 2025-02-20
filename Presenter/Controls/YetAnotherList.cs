using System.Drawing;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Controls
{
    public sealed class YetAnotherList : ListBox
    {
        private bool _darkList;
        public bool DarkList
        {
            get => _darkList;
            set
            {
                _darkList = value;
                this.Invalidate();
            }
        }

        public YetAnotherList()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.BorderStyle = BorderStyle.None;

            this.MeasureItem += YetAnotherListBox_MeasureItem;
            this.DrawItem += YetAnotherListBox_DrawItem;

            this.DarkList = false;
        }

        private void YetAnotherListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            if (this.Items.Count <= 0) return;

            e.DrawBackground();

            Color textColor;
            Color selectedBackgroundColor;
            Color normalBackgroundColor;

            if (DarkList)
            {
                textColor = Color.White;
                selectedBackgroundColor = Color.FromArgb(50, 50, 50);
                normalBackgroundColor = Color.FromArgb(45, 45, 45);
            }
            else
            {
                textColor = Color.Black;
                selectedBackgroundColor = Color.LightGray;
                normalBackgroundColor = Color.White;
            }

            Brush textBrush = new SolidBrush(textColor);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(selectedBackgroundColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(normalBackgroundColor), e.Bounds);
            }

            e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void YetAnotherListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = this.Font.Height;
        }
    }
}
