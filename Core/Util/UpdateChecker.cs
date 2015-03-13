/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System;

namespace PraiseBase.Presenter.Util
{
    public class UpdateChecker
    {
        public UpdateInformation GetNewVersion(string updateCheckUrl)
        {
            UpdateInformation rtn = new UpdateInformation();

            System.Xml.XmlTextReader reader = null;
            try
            {
                // provide the XmlTextReader with the URL of
                // our xml document
                string xmlUrl = updateCheckUrl;
                reader = new System.Xml.XmlTextReader(xmlUrl);
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
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Update check failed! " + e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
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