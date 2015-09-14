using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using PraiseBase.Presenter.Controls;
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter.Forms
{
    public class LocalizableForm : Form
    {
        // Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static readonly List<Form> AllForms = new List<Form>();

        protected void RegisterChild(Form child)
        {
            AllForms.Add(child);
        }

        /// <summary>
        /// Change language at runtime in the specified form
        /// </summary>
        protected void SetLanguage(CultureInfo lang)
        {
            log.Debug("Set culture to " + lang);

            //Set the language in the application
            System.Threading.Thread.CurrentThread.CurrentUICulture = lang;

            foreach (Form form in AllForms) 
            {
                if (form != null)
                {
                    SetLanguage(form, lang);
                }
            }

            Settings.Default.SelectedCulture = lang.Name;
        }

        /// <summary>
        /// Change language at runtime in the specified form
        /// </summary>
        protected void SetLanguage(Form form, CultureInfo lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
            if (form.MainMenuStrip != null)
            {
                ApplyResourceToControl(resources, form.MainMenuStrip, lang);
            }

            ApplyResourceToControl(resources, form, lang);

            //resources.ApplyResources(form, "$this", lang);
            form.Text = resources.GetString("$this.Text", lang);
        }

        protected void ApplyResourceToToolStrip(ComponentResourceManager resources, ToolStrip menu, CultureInfo lang)
        {
            foreach (ToolStripItem m in menu.Items)
            {
                //resources.ApplyResources(m, m.Name, lang);
                string text = resources.GetString(m.Name + ".Text", lang);
                string ttext = resources.GetString(m.Name + ".ToolTipText", lang);
                if (text != null)
                {
                    m.Text = text;
                    m.ToolTipText = ttext;
                }
                if (m.GetType() == typeof(ToolStripMenuItem))
                {
                    foreach (var d in ((ToolStripMenuItem)m).DropDownItems)
                    {
                        if (d.GetType() == typeof(ToolStripMenuItem))
                        {
                            ApplyResourceToControl(resources, (ToolStripMenuItem)d, lang);
                        }
                    }
                }
            }
        }

        protected void ApplyResourceToControl(ComponentResourceManager resources, MenuStrip menu, CultureInfo lang)
        {
            foreach (ToolStripItem m in menu.Items)
            {
                //resources.ApplyResources(m, m.Name, lang);
                string text = resources.GetString(m.Name + ".Text", lang);
                if (text != null)
                {
                    m.Text = text;
                }
                if (m.GetType() == typeof(ToolStripMenuItem))
                {
                    foreach (var d in ((ToolStripMenuItem)m).DropDownItems)
                    {
                        if (d.GetType() == typeof(ToolStripMenuItem))
                        {
                            ApplyResourceToControl(resources, (ToolStripMenuItem)d, lang);
                        }
                    }
                }
            }
        }
        protected void ApplyResourceToControl(ComponentResourceManager resources, ToolStripMenuItem menu, CultureInfo lang)
        {
            string text = resources.GetString(menu.Name + ".Text", lang);
            if (text != null)
            {
                menu.Text = text;
            }
            foreach (var d in menu.DropDownItems)
            {
                if (d.GetType() == typeof(ToolStripMenuItem))
                {
                    ApplyResourceToControl(resources, (ToolStripMenuItem)d, lang);
                }
            }
        }

        protected void ApplyResourceToControl(ComponentResourceManager resources, Control control, CultureInfo lang)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == typeof(ToolStrip))
                {
                    ApplyResourceToToolStrip(resources, (ToolStrip)c, lang);
                }
                ApplyResourceToControl(resources, c, lang);
                //resources.ApplyResources(c, c.Name, lang);
                string text = resources.GetString(c.Name + ".Text", lang);
                if (text != null)
                {
                    c.Text = text;
                }

                if (c.GetType() == typeof(CustomGroupBox))
                {
                    string title = resources.GetString(c.Name + ".Title", lang);
                    if (title != null)
                    {
                        ((CustomGroupBox)c).Title = title;
                    }
                }
                else if (c.GetType() == typeof(SearchTextBox))
                {
                    string title = resources.GetString(c.Name + ".PlaceHolderText", lang);
                    if (title != null)
                    {
                        ((SearchTextBox)c).PlaceHolderText = title;
                    }
                }
            }
        }
    }
}
