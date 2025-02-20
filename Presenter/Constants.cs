using PraiseBase.Presenter.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PraiseBase.Presenter
{
    public static class Constants
    {        
        static public List<CultureInfo> AvailableLanguages = new List<CultureInfo>();

        // Dark Mode Start Implements
        internal static string THEME_FLAG = "themeable";
        internal static int CONTRAST_THRESHOLD = 149;
        internal static Color BackgroundColor = Color.FromArgb(45, 45, 45);
        internal static Color ForegroundColor = Color.FromArgb(24, 79, 133);
        internal static Color ForegroundAccentColor = Color.FromArgb(134, 89, 179);
        internal static Color TextColor = Color.FromArgb(255, 255, 255);
        // End Dark Mode

        static Constants()
        {
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("de-CH"));
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("en-US"));
        }

        internal static Color GetContrastColor(Color c)
        {
            double brightness = c.R * 0.299 + c.G * 0.587 + c.B * 0.114;
            return brightness > Constants.CONTRAST_THRESHOLD ? Color.Black : Color.White;
        }

        private static int WindowsVersion()
        {
            //for .Net4.8 and Minor
            int result = 10;
            var reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string[] productName = reg.GetValue("ProductName").ToString().Split((char)32);
            int.TryParse(productName[1], out result);
            return result;

            //fixed .Net6
            //return System.Environment.OSVersion.Version.Major;
        }

        internal static void ApplyTheme(Form f)
        {
            SetTheme(f, Program.Theme, ColorHelper.ChangeColorBrightness(Program.Theme, 0.7));
        }

        private static void SetTheme(Form f, Color c1, Color c2)
        {
            dynamic c;
            ForegroundColor = c1;
            ForegroundAccentColor = c2;
            TextColor = GetContrastColor(Program.Theme);

            UiUtils.GetSelfAndChildrenRecursive(f).ToList().ForEach(x =>
            {
                if (Program.isDarkMode)
                {
                    f.BackColor = Color.FromArgb(40, 40, 40);
                }
                else
                {
                    f.BackColor = Color.FromArgb(255, 255, 255);
                }

                c = x;

                if (x is Button)
                {
                    //if ((string)c.Tag == Constants.THEME_FLAG)
                    if (c.Tag is string tag && tag == Constants.THEME_FLAG)
                    {
                        c.ForeColor = TextColor;
                        c.BackColor = c1;
                        c.FlatAppearance.BorderColor = c1;
                        c.FlatAppearance.MouseDownBackColor = c2;
                        c.FlatAppearance.MouseOverBackColor = c2;
                        c.FlatAppearance.BorderSize = 0;
                    }
                }

                if (x is SearchTextBox)
                {
                    if (Program.isDarkMode)
                    {
                        c.TextBoxBackColor = Color.FromArgb(45, 45, 45);
                        c.TextBoxForeColor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        c.TextBoxBackColor = Color.FromArgb(255, 255, 255);
                        c.TextBoxForeColor = Color.FromArgb(45, 45, 45);
                    }
                }

                if (x is Panel)
                {
                    if (c.Tag is string tag && tag == Constants.THEME_FLAG)
                    {
                        if (Program.isDarkMode)
                        {
                            c.BackColor = Color.FromArgb(30, 32, 36);
                        }
                        else
                        {
                            c.BackColor = Color.FromArgb(225, 223, 219);
                        }
                    }
                }

                if (x is TextBox)
                {
                    if (c.Tag is string tag && tag == Constants.THEME_FLAG)
                    {
                        if (Program.isDarkMode)
                        {
                            c.BackColor = Color.FromArgb(40, 40, 40);
                            c.ForeColor = Color.FromArgb(255, 255, 255);
                        }
                        else
                        {
                            c.BackColor = Color.FromArgb(255, 255, 255);
                            c.ForeColor = Color.FromArgb(45, 45, 45);
                        }
                    }
                }

                if (x is NumericUpDown)
                {
                    c.ForeColor = TextColor;
                    c.BackColor = c1;
                }

                if (x is DataGridView)
                {
                    if (Program.isDarkMode)
                    {
                        c.BackgroundColor = Color.Black;
                        c.GridColor = Color.FromArgb(40, 40, 40);
                        c.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                        c.DefaultCellStyle.ForeColor = Color.White;

                        c.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
                        c.DefaultCellStyle.SelectionForeColor = Color.White;
                        c.ColumnHeadersHeight = 140;

                        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        c.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    }
                    else
                    {
                        c.BackgroundColor = Color.White;
                        c.DefaultCellStyle.BackColor = Color.White;
                        c.DefaultCellStyle.ForeColor = Color.Black;

                        c.DefaultCellStyle.SelectionBackColor = c.DefaultCellStyle.SelectionBackColor;
                        c.DefaultCellStyle.SelectionForeColor = c.DefaultCellStyle.SelectionForeColor;

                        c.ColumnHeadersHeight = 140;
                        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        c.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    }
                }

                if (x is ListView || x is ListBox || x is TreeView)
                {
                    if (Program.isDarkMode)
                    {
                        c.ForeColor = TextColor;
                        c.BackColor = Color.FromArgb(45, 45, 45);
                    }
                    else
                    {
                        c.ForeColor = Color.FromArgb(45, 45, 45);
                        c.BackColor = Color.FromArgb(255, 255, 255);
                    }
                }

                if (x is SongDetail)
                {
                    if (Program.isDarkMode)
                    {
                        c.BackColor = Color.FromArgb(45, 45, 45);
                        c.ForeColor = Color.FromArgb(255, 255, 255);
                        c.SlideNormalBackColor = Color.FromArgb(45, 45, 45);
                        c.SlideNormalForeColor = Color.FromArgb(255, 255, 255);
                        c.SlideActiveBackColor = Color.FromArgb(30, 32, 36);
                        c.SlideActiveForeColor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        c.BackColor = Color.FromArgb(255, 255, 255);
                        c.ForeColor = Color.FromArgb(45, 45, 45);
                        c.SlideNormalBackColor = Color.FromArgb(255, 255, 255);
                        c.SlideNormalForeColor = Color.FromArgb(45, 45, 45);
                        c.SlideActiveBackColor = SystemColors.Highlight;
                        c.SlideActiveForeColor = Color.FromArgb(255, 255, 255);
                    }
                }

                if (x is YetAnotherList)
                {
                    if (Program.isDarkMode)
                    {
                        c.ForeColor = TextColor;
                        c.BackColor = Color.FromArgb(45, 45, 45);
                        c.DarkList = true;
                    }
                    else
                    {
                        c.ForeColor = Color.FromArgb(45, 45, 45);
                        c.BackColor = Color.FromArgb(255, 255, 255);
                        c.DarkList = false;
                    }
                }

                if (x is YetAnotherSelect)
                {
                    c.ForeColor = TextColor;
                    c.BackColor = c1;
                    c.BorderColor = Color.FromArgb(24, 79, 133);
                }

                if (x is YetAnotherTabs)
                {
                    if (Program.isDarkMode)
                    {
                        c.TabBackColorActive = BackgroundColor;
                        c.TabBackColorInActive = BackgroundColor;
                    }
                    else
                    {
                        c.TabBackColorActive = Color.FromArgb(255, 255, 255);
                        c.TabBackColorInActive = ColorHelper.ChangeColorBrightness(TextColor, 0.7);
                    }
                }

                if (x is TabPage)
                {
                    if (Program.isDarkMode)
                    {
                        c.BackColor = BackgroundColor;
                    }
                    else
                    {
                        c.BackColor = Color.FromArgb(255, 255, 255);
                    }
                }

                if (x is CustomGroupBox)
                {
                    if (Program.isDarkMode)
                    {
                        c.BackColor = Color.FromArgb(45, 45, 45);
                        c.GradientStartColor = Color.FromArgb(30, 32, 36); //32, 194, 222
                        c.GradientEndColor = Color.FromArgb(30, 32, 36); //24, 79, 133
                    }
                    else
                    {
                        c.BackColor = Color.FromArgb(255, 255, 255);
                        c.GradientStartColor = Color.FromArgb(24, 79, 133); //32, 194, 222
                        c.GradientEndColor = Color.FromArgb(24, 79, 133); //24, 79, 133
                    }
                }

                if (x is LinkLabel)
                {
                    if ((string)c.Tag == Constants.THEME_FLAG)
                    {
                        c.LinkColor = c1;
                        c.VisitedLinkColor = c1;
                        c.ActiveLinkColor = c2;
                    }
                }

                if (x is CheckBox || x is RadioButton || x is Label || x is GroupBox)
                {
                    if ((string)c.Tag == Constants.THEME_FLAG)
                    {
                        c.ForeColor = c1;
                    }
                    else
                    {
                        if (Program.isDarkMode)
                        {
                            c.ForeColor = Color.FromArgb(255, 255, 255);
                        }
                        else
                        {
                            c.ForeColor = Color.FromArgb(45, 45, 45);
                        }
                    }
                }

                if (x is ToolStrip || x is MenuStrip || x is StatusStrip)
                {
                    if ((string)c.Tag == Constants.THEME_FLAG)
                    {
                        if (Program.isDarkMode)
                        {
                            c.BackColor = Color.FromArgb(40, 40, 40);
                            c.ForeColor = Color.FromArgb(255, 255, 255);
                            c.Renderer = new MenuRenderer();
                        }
                        else
                        {
                            c.BackColor = Color.FromArgb(255, 255, 255);
                            c.ForeColor = Color.FromArgb(45, 45, 45);
                            c.Renderer = null;
                        }
                    }
                }

                c.Invalidate();
            });
        }
    }
}
