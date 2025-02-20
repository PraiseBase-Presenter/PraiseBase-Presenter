using System.Windows.Forms;
using System.Collections.Generic;

namespace PraiseBase.Presenter
{
    public static class UiUtils
    {
        public static IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);
            return controls;
        }

        public static void InverseSelection(this ListView lv)
        {
            lv.BeginUpdate();
            foreach (ListViewItem item in lv.Items)
            {
                item.Selected = !item.Selected;
            }
            lv.EndUpdate();
        }

        public static void SelectAll(this ListBox listbox)
        {
            listbox.BeginUpdate();
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                listbox.SetSelected(i, true);
            }
            listbox.EndUpdate();
        }

        public static void InverseSelection(this ListBox listbox)
        {
            listbox.BeginUpdate();
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                listbox.SetSelected(i, !listbox.GetSelected(i));
            }
            listbox.EndUpdate();
        }
    }
}
