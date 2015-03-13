using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PraiseBase.Presenter.Controls
{
    public class TreeViewLabelEdit : TreeView
    {
        #region Component Designer generated code

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            this.HideSelection = false;
            this.LabelEdit = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion Component Designer generated code

        private const int WmTimer = 0x0113;
        private bool _triggerLabelEdit;
        private string _viewedLabel;
        private string _editedLabel;
        private bool _wasDoubleClick;

        public TreeViewLabelEdit()
        {
            InitializeComponent();
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = GetNodeAt(e.X, e.Y);
                if (tn != null)
                    SelectedNode = tn;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var tn = SelectedNode;
                if (tn == GetNodeAt(e.X, e.Y))
                {
                    if (_wasDoubleClick)
                        _wasDoubleClick = false;
                    else
                    {
                        _triggerLabelEdit = true;
                    }
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            // put node label to initial state
            // to ensure that in case of label editing cancelled
            // the initial state of label is preserved
            SelectedNode.Text = _viewedLabel;

            // base.OnBeforeLabelEdit is not called here
            // it is called only from StartLabelEdit
        }

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            LabelEdit = false;
            e.CancelEdit = true;
            if (e.Label == null)
            {
                return;
            }
            ValidateLabelEditEventArgs ea = new ValidateLabelEditEventArgs(e.Label);
            OnValidateLabelEdit(ea);
            if (ea.Cancel)
            {
                e.Node.Text = _editedLabel;
                LabelEdit = true;
                e.Node.BeginEdit();
            }
            else
                base.OnAfterLabelEdit(e);
        }

        public void BeginEdit()
        {
            StartLabelEdit();
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (_triggerLabelEdit)
                if (m.Msg == WmTimer)
                {
                    _triggerLabelEdit = false;
                    StartLabelEdit();
                }
            base.OnNotifyMessage(m);
        }

        public void StartLabelEdit()
        {
            TreeNode tn = SelectedNode;
            _viewedLabel = tn.Text;

            NodeLabelEditEventArgs e = new NodeLabelEditEventArgs(tn);
            base.OnBeforeLabelEdit(e);

            _editedLabel = tn.Text;

            LabelEdit = true;
            tn.BeginEdit();
        }

        protected override void OnClick(EventArgs e)
        {
            _triggerLabelEdit = false;
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            _wasDoubleClick = true;
            base.OnDoubleClick(e);
        }

        public event ValidateLabelEditEventHandler ValidateLabelEdit;

        protected virtual void OnValidateLabelEdit(ValidateLabelEditEventArgs e)
        {
            if (ValidateLabelEdit != null)
            {
                ValidateLabelEdit(this, e);
            }
        }

        public delegate void ValidateLabelEditEventHandler(object sender, ValidateLabelEditEventArgs e);
    }

    public class ValidateLabelEditEventArgs : CancelEventArgs
    {
        public ValidateLabelEditEventArgs(string label)
        {
            Label = label;
            Cancel = false;
        }

        public string Label { get; set; }
    }
}