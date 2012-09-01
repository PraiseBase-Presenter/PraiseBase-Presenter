using System;

namespace Pbp
{
    public class UpdateCheck
    {
        public class UpdateInformation
        {
            public Version CurrentVersion { get; set; }

            public Version OnlineVersion { get; set; }

            public string DownloadUrl { get; set; }

            public bool UpdateAvailable { get; set; }

            public UpdateInformation()
            {
                UpdateAvailable = false;
                DownloadUrl = string.Empty;
            }
        }

        public static void DoCheck()
        {
            UpdateInformation ui = getNewVersion();

            if (ui.UpdateAvailable)
            {
                // ask the user if he would like
                // to download the new version
                string title = "Update verfügbar";
                string question = "Es ist ein Update auf Version " + ui.OnlineVersion + " verfügbar (Sie haben " + ui.CurrentVersion + "). \nSoll das Update heruntergeladen werden?";
                if (System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show(question, title,
                                 System.Windows.Forms.MessageBoxButtons.YesNo,
                                 System.Windows.Forms.MessageBoxIcon.Question))
                {
                    // navigate the default web
                    // browser to our app
                    // homepage (the url
                    // comes from the xml content)
                    System.Diagnostics.Process.Start(ui.DownloadUrl);
                }
            }
        }

        public static void downloadNewVersion()
        {
            System.Net.WebClient Client = new System.Net.WebClient();

            //Client.DownloadFile("http://www.csharpfriends.com/Members/index.aspx", " index.aspx");
        }

        public static UpdateInformation getNewVersion()
        {
            UpdateInformation rtn = new UpdateInformation();

            System.Xml.XmlTextReader reader;
            try
            {
                // provide the XmlTextReader with the URL of
                // our xml document
                string xmlURL = Properties.Settings.Default.UpdateCheckUrl;
                reader = new System.Xml.XmlTextReader(xmlURL);
                // simply (and easily) skip the junk at the beginning
                reader.MoveToContent();
                // internal - as the XmlTextReader moves only
                // forward, we save current xml element name
                // in elementName variable. When we parse a
                // text node, we refer to elementName to check
                // what was the node name
                string elementName = "";

                // we check if the xml starts with a proper
                // "ourfancyapp" element node
                if ((reader.NodeType == System.Xml.XmlNodeType.Element) &&
                    (reader.Name == "praisebasepresenter"))
                {
                    while (reader.Read())
                    {
                        // when we find an element node,
                        // we remember its name
                        if (reader.NodeType == System.Xml.XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...
                            if ((reader.NodeType == System.Xml.XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                // we check what the name of the node was
                                switch (elementName)
                                {
                                    case "version":

                                        // thats why we keep the version info
                                        // in xxx.xxx.xxx.xxx format
                                        // the Version class does the
                                        // parsing for us
                                        rtn.OnlineVersion = new Version(reader.Value);
                                        break;

                                    case "url":
                                        rtn.DownloadUrl = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
                if (reader != null) reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Update check failed! " + e.Message);
            }

            // get the running version
            rtn.CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // compare the versions
            if (rtn.OnlineVersion != null && rtn.CurrentVersion.CompareTo(rtn.OnlineVersion) < 0)
            {
                rtn.UpdateAvailable = true;
            }
            return rtn;
        }
    }
}