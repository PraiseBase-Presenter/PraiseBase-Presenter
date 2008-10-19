using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class EditorChild : Form
    {
        Song sng;
        Settings setting;

        public EditorChild(string fileName)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            setting = new Settings();

            if (fileName != null)
            {
                sng = new Song(fileName);
                if (sng.isValid)
                {
                    this.Text = sng.title + " ("+fileName+")";

                    populateTree();

                    treeViewContents.SelectedNode = treeViewContents.Nodes[0];
                    
                }
                else
                {
                    MessageBox.Show("Diese Lieddatei ist leider fehlerhaft!","Liededitor",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                treeViewContents.Nodes.Add("Neues Lied");
            }
        }

        public void populateTree()
        {
            treeViewContents.Nodes.Clear();
            treeViewContents.Nodes.Add(sng.title);
            int j = 0;
            foreach (Song.Part part in sng.parts)
            {
                TreeNode partNode = new TreeNode(part.caption);
                int i = 0;
                foreach (Song.Slide slide in part.partSlides)
                {
                    TreeNode slideNode = new TreeNode("Folie " + (i + 1).ToString());
                    i++;
                    partNode.Nodes.Add(slideNode);
                }
                treeViewContents.Nodes[0].Nodes.Add(partNode);
                j++;
            }
            treeViewContents.ExpandAll();
        }

        private void treeViewContents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewContents.SelectedNode.Level == 2)
            {
                showSongControls(false);
                showPartControls(false);
                showSlideControls(true);
               
                Song.Slide sld = sng.parts[treeViewContents.SelectedNode.Parent.Index].partSlides[treeViewContents.SelectedNode.Index];
                textBoxSongText.Text = sld.lineBreakText();
                preview(sld);
            }
            else if (treeViewContents.SelectedNode.Level == 1)
            {
                showSlideControls(false);
                showSongControls(false);
                showPartControls(true);
                
                Song.Part prt = sng.parts[treeViewContents.SelectedNode.Index];
                textBoxSongPartCaption.Text = prt.caption;

            }
            else
            {
                showSlideControls(false);
                showPartControls(false);
                showSongControls(true);
                
                textBoxSongTitle.Text = sng.title;

                comboBoxLanguage.Items.Clear();
                comboBoxLanguage.Text = sng.language;
                comboBoxLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBoxLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
                foreach (string str in setting.languages)
                {
                    comboBoxLanguage.Items.Add(str);
                }

                comboBoxSongParts.Items.Clear();
                comboBoxSongParts.Text = "";
                comboBoxSongParts.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBoxSongParts.AutoCompleteSource = AutoCompleteSource.ListItems;
                foreach (string str in setting.songParts)
                {
                    comboBoxSongParts.Items.Add(str);
                }

                int i=0;
                checkedListBoxTags.Items.Clear();
                foreach (string str in setting.tags)
                {
                    checkedListBoxTags.Items.Add(str);
                    if (sng.tags.Contains(str))
                    {
                        checkedListBoxTags.SetItemChecked(i,true);
                    }
                    i++;
                }
            }
        }

        private void showSlideControls(bool value)
        {
            textBoxSongText.Visible = value;
            pictureBoxPreview.Visible = value;
        }

        private void showSongControls(bool value)
        {
            groupBoxSongSettings.Visible = value;
            groupBoxNewSongPart.Visible = value;
        }

        private void showPartControls(bool value)
        {
            groupBoxNewSlide.Visible = value;
            groupBoxSongPart.Visible = value;
        }

        private void preview(Song.Slide slide)
        {
            Image background;
            if (slide.imageNumber >= 0)
                background = sng.getImage(slide.imageNumber);
            else
                background = null;
            string str = "";
            str = slide.lineBreakText();


            int w = pictureBoxPreview.Width;
            int h = pictureBoxPreview.Height;
            int padding = 10;

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            Font font = setting.projectionMasterFont;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            int textX = w / 2;
            int textY = h / 2;

            // Background color
            gr.FillRectangle(new SolidBrush(setting.projectionBackColor), 0, 0, w, h);

            // Background image
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
            }


            float realFontWidth;
            float realFontHeight;

            if (setting.projectionFontScaling)
            {
                realFontWidth = gr.MeasureString(str, font).Width;
                if (realFontWidth > w - padding)
                {
                    font = new Font(font.FontFamily, ((w - padding) / realFontWidth) * font.Size, font.Style);
                }
                realFontHeight = gr.MeasureString(str, font).Height;
                if (realFontHeight > h - padding)
                {
                    font = new Font(font.FontFamily, ((h - padding) / realFontHeight) * font.Size, font.Style);
                }
            }
            realFontWidth = gr.MeasureString(str, font).Width;
            realFontHeight = gr.MeasureString(str, font).Height;

            switch (slide.horizAlign)
            {
                case Song.SongTextHorizontalAlign.left:
                    textX = padding;
                    strFormat.Alignment = StringAlignment.Near;
                    break;
                case Song.SongTextHorizontalAlign.center:
                    textX = w / 2;
                    strFormat.Alignment = StringAlignment.Center;
                    break;
                case Song.SongTextHorizontalAlign.right:
                    textX = w - padding;
                    strFormat.Alignment = StringAlignment.Far;
                    break;
            }
            switch (slide.vertAlign)
            {
                case Song.SongTextVerticalAlign.top:
                    strFormat.LineAlignment = StringAlignment.Near;
                    textY = padding;
                    break;
                case Song.SongTextVerticalAlign.center:
                    strFormat.LineAlignment = StringAlignment.Center;
                    textY = h / 2;
                    break;
                case Song.SongTextVerticalAlign.bottom:
                    strFormat.LineAlignment = StringAlignment.Far;
                    textY = h - padding;
                    break;
            } 




            gr.DrawString(str, font, new SolidBrush(setting.projectionMasterFontColor), new Point(textX, textY), strFormat);


            pictureBoxPreview.Image = bmp;
            gr.Dispose();
        }

        private void textBoxSongText_TextChanged(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode.Level == 2)
            {
                int partIdx = treeViewContents.SelectedNode.Parent.Index;
                int slideIdx = treeViewContents.SelectedNode.Index;

                sng.setSlideText(textBoxSongText.Text, partIdx, slideIdx);
                preview(sng.parts[partIdx].partSlides[slideIdx]);
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            sng.title = textBoxSongTitle.Text;
            treeViewContents.Nodes[0].Text = sng.title;
        }

        private void buttonNewSongPart_Click(object sender, EventArgs e)
        {
            comboBoxSongParts.Text = comboBoxSongParts.Text.Trim();
            if (comboBoxSongParts.Text == "")
            {
                MessageBox.Show("Der Name für diesen Liedteil fehlt!","Liededitor",MessageBoxButtons.OK,MessageBoxIcon.Error);
                comboBoxSongParts.Focus();
                return;
            }
            Song.Part prt = new Song.Part();
            prt.caption = comboBoxSongParts.Text;
            prt.partSlides = new List<Song.Slide>();
            Song.Slide sld = new Song.Slide();
            sld.imageNumber = -1;
            prt.partSlides.Add(sld);
            sng.parts.Add(prt);

            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[0].LastNode.LastNode;
            textBoxSongText.Focus();

            comboBoxSongParts.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populateTree();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            sng.language = comboBoxLanguage.Text;
        }

        private void checkedListBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            sng.resetTags();
            int i = 0;
            foreach (string str in checkedListBoxTags.Items)
            {
                if (checkedListBoxTags.GetItemChecked(i))
                {
                    sng.addTag(str);
                }
                i++;
            }
        }

        private void textBoxSongPartCaption_TextChanged(object sender, EventArgs e)
        {
            string cap = textBoxSongPartCaption.Text.Trim();
            sng.setPartCaption(cap, treeViewContents.SelectedNode.Index);
            treeViewContents.SelectedNode.Text = cap;
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            int partId = 0;
            Song.Slide sld = new Song.Slide();
            sld.imageNumber = -1;
            if (treeViewContents.SelectedNode.Level == 1)
            {
                partId = treeViewContents.SelectedNode.Index;
                sng.parts[partId].partSlides.Add(sld);
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].LastNode;
            }
            if (treeViewContents.SelectedNode.Level == 2)
            {
                partId = treeViewContents.SelectedNode.Parent.Index;
                sng.parts[partId].partSlides.Add(sld);
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].LastNode;
            }           
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 2)
                {
                    buttonAddNewSlide_Click(sender, e);
                }
                else if (treeViewContents.SelectedNode.Level == 1)
                {
                    buttonAddNewSlide_Click(sender, e);
                }
                else
                {
                    Song.Part prt = new Song.Part();
                    prt.caption = "Neuer Liedteil";
                    prt.partSlides = new List<Song.Slide>();
                    Song.Slide sld = new Song.Slide();
                    sld.imageNumber = -1;
                    prt.partSlides.Add(sld);
                    sng.parts.Add(prt);

                    populateTree();
                    treeViewContents.SelectedNode = treeViewContents.Nodes[0].LastNode.LastNode;
                }
            }
        }

        private void buttonDelItem_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 2)
                {
                    if (MessageBox.Show("Folie wirklich löschen?","Liededitor",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int partId = treeViewContents.SelectedNode.Parent.Index;
                        int slideId = treeViewContents.SelectedNode.Index;
                        sng.parts[partId].partSlides.RemoveAt(slideId);
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 1)
                {
                    if (MessageBox.Show("Liedteil wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int partId = treeViewContents.SelectedNode.Index;
                        sng.parts.RemoveAt(partId);
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[0];
                    }
                }
                else
                {
                }
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {

        }

 

  
    }
}
