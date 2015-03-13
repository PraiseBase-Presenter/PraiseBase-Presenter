using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Controls
{
    public class DragAndDropListView : ListView
    {
        private const string Reorder = "Reorder";

        private bool _allowRowReorder = true;

        public bool AllowRowReorder
        {
            get
            {
                return _allowRowReorder;
            }
            set
            {
                _allowRowReorder = value;
                AllowDrop = value;
            }
        }

        public new SortOrder Sorting
        {
            get
            {
                return SortOrder.None;
            }
            set
            {
                base.Sorting = SortOrder.None;
            }
        }

        public DragAndDropListView()
        {
            AllowRowReorder = true;
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            if (!AllowRowReorder)
            {
                return;
            }
            if (SelectedItems.Count == 0)
            {
                return;
            }
            Point cp = PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            int dropIndex = dragToItem.Index;
            if (dropIndex > SelectedItems[0].Index)
            {
                dropIndex++;
            }
            ArrayList insertItems = new ArrayList(SelectedItems.Count);

            foreach (ListViewItem item in SelectedItems)
            {
                insertItems.Add(item.Clone());
            }

            for (int i = insertItems.Count - 1; i >= 0; i--)
            {
                ListViewItem insertItem = (ListViewItem)insertItems[i];
                Items.Insert(dropIndex, insertItem);
            }
            int removeIdx = 0;
            foreach (ListViewItem removeItem in SelectedItems)
            {
                removeIdx = removeItem.Index;
                Items.Remove(removeItem);
            }
            if (dropIndex > removeIdx)
                Items[dropIndex - 1].Selected = true;
            else
                Items[dropIndex].Selected = true;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (!AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Point cp = PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = GetItemAt(cp.X, cp.Y);

            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (SelectedItems.Cast<ListViewItem>().Any(moveItem => moveItem.Index == hoverItem.Index))
            {
                e.Effect = DragDropEffects.None;
                hoverItem.EnsureVisible();
                return;
            }
            base.OnDragOver(e);
            String text = (String)e.Data.GetData(Reorder.GetType());
            if (String.Compare(text, Reorder, StringComparison.Ordinal) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            if (!AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            base.OnDragEnter(e);
            String text = (String)e.Data.GetData(Reorder.GetType());
            e.Effect = String.Compare(text, Reorder, StringComparison.Ordinal) == 0 ? DragDropEffects.Move : DragDropEffects.None;
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
            if (!AllowRowReorder)
            {
                return;
            }
            DoDragDrop(Reorder, DragDropEffects.Move);
        }
    }
}