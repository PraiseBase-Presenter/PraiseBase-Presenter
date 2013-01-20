using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Pbp.Properties;
using Pbp.IO;
using Pbp.Data.Song;

namespace Pbp.Forms
{
    public partial class SongImporter : Form
    {
        /// <summary>
        /// Specifies the import type
        /// </summary>
        public enum ImportFormat
        {
            /// <summary>
            /// PraiseBox Database (http://www.praisebox.ch)
            /// </summary>
            PraiseBox,

            /// <summary>
            /// Powerpraise Songs (http://www.powerpraise.ch)
            /// </summary>
            PowerPraise,

            /// <summary>
            /// Songbeamer Songs (http://www.songbeamer.de)
            /// </summary>
            SongBeamer,

            /// <summary>
            /// WorshipSystem Database (http://www.worshipsystem.com)
            /// </summary>
            WorshipSystem
        }

        private ImportFormat _format;

        /// <summary>
        /// Imports songs from other systems
        /// </summary>
        /// <param name="importFormat">Import type</param>
        public SongImporter(ImportFormat importFormat)
        {
            _format = importFormat;
            InitializeComponent();
        }

        private void PraiseBoxImporter_Load(object sender, EventArgs e)
        {
            OpenFileDialog dlg;

            switch (_format)
            {
                case ImportFormat.PraiseBox:

                    #region PraiseBox Importer

                    dlg = new OpenFileDialog();
                    dlg.Title = Properties.StringResources.OpenPraiseBoxDatabase;
                    dlg.Filter = Properties.StringResources.OpenPraiseBoxDatabase + " (*.pbd)|*.pbd|Alle Dateien (*.*)|*.*";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName;
                        DataSet myDataSet = new DataSet();
                        OleDbConnection myAccessConn = null;
                        try
                        {
                            myAccessConn = new OleDbConnection(strAccessConn);
                            myAccessConn.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }

                        OleDbDataReader aReader;
                        try
                        {
                            OleDbCommand aCommand = new OleDbCommand("select * from SongText", myAccessConn);
                            aReader = aCommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }

                        //Iterate throuth the database
                        while (aReader.Read())
                        {
                            RichTextBox rtf = new RichTextBox();
                            rtf.Rtf = aReader.GetString(2);
                            string text = rtf.Text.ToString().Trim();
                            text = text.Replace("\n", Environment.NewLine);
                            string[] prts = text.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                            Song sng = new Song();
                            sng.Title = aReader.GetString(1);

                            Regex rex = new Regex(".+:");
                            int p = 0;
                            foreach (String pri in prts)
                            {
                                if (p > 0)
                                {
                                    sng.Parts.Add(new SongPart());
                                    sng.Parts[p].Slides.Add(new SongSlide(sng));
                                }
                                Match mat = rex.Match(pri);
                                sng.Parts[p].Caption = mat.Value.Substring(0, mat.Value.Length - 1);
                                sng.Parts[p].Slides[0].Text = pri.Substring(mat.Value.Length + 1);
                                p++;
                            }

                            ListViewItem lvi = new ListViewItem(sng.Title);
                            lvi.Checked = true;
                            lvi.Tag = sng;
                            listViewSongs.Items.Add(lvi);
                        }

                        //close the reader
                        aReader.Close();

                        //close the connection Its important.
                        myAccessConn.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                    break;

                    #endregion PraiseBox Importer

                case ImportFormat.WorshipSystem:

                    #region WorshipSystem Importer

                    dlg = new OpenFileDialog();
                    dlg.Title = Properties.StringResources.OpenWorshipSystemDatabase;
                    dlg.Filter = Properties.StringResources.OpenWorshipSystemDatabase + " (*.mdb)|*.mdb|Alle Dateien (*.*)|*.*";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName;
                        DataSet myDataSet = new DataSet();
                        OleDbConnection myAccessConn = null;
                        try
                        {
                            myAccessConn = new OleDbConnection(strAccessConn);
                            myAccessConn.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }

                        OleDbDataReader aReader;
                        try
                        {
                            OleDbCommand aCommand = new OleDbCommand("select * from Songs", myAccessConn);
                            aReader = aCommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Properties.StringResources.Sorry + "! " + ex.Message, Properties.StringResources.DatabaseError, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }

                        //Iterate throuth the database
                        while (aReader.Read())
                        {
                            Song sng = new Song();
                            sng.Title = aReader.GetString(1);

                            string text = aReader.GetString(4);
                            text = text.Replace("\r\n", Environment.NewLine);
                            string[] prts = text.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                            //Regex rex = new Regex(".+:");
                            int p = 0;
                            foreach (String pri in prts)
                            {
                                string transl = string.Empty;
                                string txt = string.Empty;
                                string[] priPrts = pri.Split(new string[] { "<S>" }, StringSplitOptions.RemoveEmptyEntries);
                                if (priPrts.Count() < 2)
                                    priPrts = pri.Split(new string[] { "<s>" }, StringSplitOptions.RemoveEmptyEntries);

                                if (priPrts.Count() == 1)
                                {
                                    txt = priPrts[0];
                                }
                                else if (priPrts.Count() == 2)
                                {
                                    txt = priPrts[0];
                                    transl = priPrts[1];
                                }
                                else
                                    txt = pri;

                                if (p > 0)
                                {
                                    sng.Parts.Add(new SongPart());
                                    sng.Parts[p].Slides.Add(new SongSlide(sng));
                                }

                                //Match mat = rex.Match(pri);
                                sng.Parts[p].Caption = "Teil " + (p + 1).ToString();
                                sng.Parts[p].Slides[0].Text = txt;
                                if (transl != string.Empty)
                                {
                                    sng.Parts[p].Slides[0].Text = transl;
                                }
                                p++;
                            }

                            ListViewItem lvi = new ListViewItem(sng.Title);
                            lvi.Checked = true;
                            lvi.Tag = sng;
                            listViewSongs.Items.Add(lvi);
                        }

                        //close the reader
                        aReader.Close();

                        //close the connection Its important.
                        myAccessConn.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                    break;

                    #endregion WorshipSystem Importer

                default:
                    MessageBox.Show(Properties.StringResources.Sorry + "! " + Properties.StringResources.NoSongImporterAvailable, 
                        Properties.StringResources.SongImporter, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
            }
        }

        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                Song sng = ((Song)(listViewSongs.SelectedItems[0].Tag));

                listViewDetails.Items.Clear();
                foreach (SongPart prt in sng.Parts)
                {
                    foreach (SongSlide sld in prt.Slides)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { prt.Caption, sld.GetOneLineText() });
                        listViewDetails.Items.Add(lvi);
                    }
                }
                listViewDetails.Columns[0].Width = -2;
                listViewDetails.Columns[1].Width = -2;
            }
        }

        private void buttonSelAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                listViewSongs.Items[x].Checked = true;
            }
        }

        private void buttonDSelAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                listViewSongs.Items[x].Checked = false;
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            List<String> filesToOpen = new List<string>();
            int cnt = 0;
            for (int x = 0; x < listViewSongs.Items.Count; x++)
            {
                if (listViewSongs.Items[x].Checked)
                {
                    string fileName = Settings.Default.DataDirectory + Path.DirectorySeparatorChar
                        + Settings.Default.SongDir + Path.DirectorySeparatorChar
                        + ((Song)listViewSongs.Items[x].Tag).Title + SongFileWriterFactory.Instance.CreateFactory(SongFileWriterFactory.Instance.PreferredType).FileExtension;
                    if ((File.Exists(fileName) && (MessageBox.Show(string.Format(Properties.StringResources.SongExistsAlready, ((Song)listViewSongs.Items[x].Tag).Title) 
                        + Properties.StringResources.Overwrite + "?", Properties.StringResources.SongImporter, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) || !File.Exists(fileName))
                    {
                        Song sng = (Song)listViewSongs.Items[x].Tag;
                        if (sng.GUID == Guid.Empty)
                        {
                            sng.GUID = SongManager.Instance.GenerateGuid();
                        }
                        // TODO Exception handling
                        SongFileWriterFactory.Instance.CreateFactoryByFile(fileName).Save(fileName, sng);
                        filesToOpen.Add(fileName);
                        cnt++;
                    }
                }
            }
            if (cnt > 0)
            {
                MessageBox.Show(string.Format(Properties.StringResources.SongsImported, cnt.ToString()), Properties.StringResources.SongImporter, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (checkBoxUseEditor.Checked)
                {
                    for (int x = 0; x < listViewSongs.Items.Count; x++)
                    {
                        if (listViewSongs.Items[x].Checked)
                        {
                            SongEditor.getInstance().openSong(filesToOpen[x]);
                        }
                    }
                    SongEditor.getInstance().Show();
                }

                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}