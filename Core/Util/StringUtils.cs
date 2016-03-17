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
using System.Collections;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace PraiseBase.Presenter.Util
{
    public static class StringUtils
    {
        /// <summary>
        ///     Gibt einen MD5 Hash als String zurück
        /// </summary>
        /// <param name="TextToHash">string der Gehasht werden soll.</param>
        /// <returns>Hash als string.</returns>
        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            var textToHash = Encoding.Default.GetBytes(TextToHash);
            var result = md5.ComputeHash(textToHash);

            return BitConverter.ToString(result);
        }

        public static string GetMD5Hash(Bitmap bmp)
        {
            /*
            ImageConverter converter = new ImageConverter();
            byte[] rawImageData = converter.ConvertTo(img, typeof(byte[])) as byte[];
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(rawImageData);*/

            var ic = new ImageConverter();
            var btImage1 = new byte[1];
            btImage1 = (byte[]) ic.ConvertTo(bmp, btImage1.GetType());
            var shaM = new SHA256Managed();
            var hash = shaM.ComputeHash(btImage1);

            return BitConverter.ToString(hash);
        }

        public static string ConvertString(string unicode)
        {
            var sb = new StringBuilder();
            foreach (var c in unicode)
                if (c >= 32 && c <= 255)
                    sb.Append(c);
            return sb.ToString();
        }

        public static string[] Wrap(string text, int maxLength)
        {
            text = text.Replace(Environment.NewLine, " ");
            text = text.Replace(".", ". ");
            text = text.Replace(">", "> ");
            text = text.Replace("\t", " ");
            text = text.Replace(",", ", ");
            text = text.Replace(";", "; ");
            text = text.Replace("<br>", " ");
            text = text.Replace(" ", " ");

            var words = text.Split(' ');
            var currentLineLength = 0;
            var lines = new ArrayList(text.Length/maxLength);
            var currentLine = "";
            var inTag = false;

            foreach (var currentWord in words)
            {
                //ignore html
                if (currentWord.Length > 0)
                {
                    if (currentWord.Substring(0, 1) == "<")
                        inTag = true;

                    if (inTag)
                    {
                        //handle filenames inside html tags
                        if (currentLine.EndsWith("."))
                        {
                            currentLine += currentWord;
                        }
                        else
                            currentLine += " " + currentWord;

                        if (currentWord.Contains(">"))
                            inTag = false;
                    }
                    else
                    {
                        if (currentLineLength + currentWord.Length + 1 < maxLength)
                        {
                            currentLine += (currentLine.Length > 0 ? " " : "") + currentWord;
                            currentLineLength += (currentWord.Length + 1);
                        }
                        else
                        {
                            lines.Add(currentLine);
                            currentLine = currentWord;
                            currentLineLength = currentWord.Length;
                        }
                    }
                }
            }
            if (currentLine != "")
                lines.Add(currentLine);

            var textLinesStr = new string[lines.Count];
            lines.CopyTo(textLinesStr, 0);
            return textLinesStr;
        }

        /// <summary>
        ///     Serialize object to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <param name="returnHash"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T toSerialize, bool returnHash)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());
            var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            if (returnHash)
            {
                return GetMD5Hash(textWriter.ToString());
            }
            return textWriter.ToString();
        }
    }
}