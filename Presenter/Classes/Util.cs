/*
 *   PraiseBase Presenter 
 *   The open source lyrics and image projection software for churches
 *   
 *   http://code.google.com/p/praisebasepresenter
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pbp
{
	class Util
	{

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

string[] Words = text.Split(' ');
int currentLineLength = 0;
System.Collections.ArrayList Lines = new System.Collections.ArrayList(text.Length / maxLength);
string currentLine = "";
bool InTag = false;

foreach (string currentWord in Words)
{
//ignore html
if (currentWord.Length > 0)
{

if (currentWord.Substring(0,1) == "<")
InTag = true;

if (InTag)
{
//handle filenames inside html tags
if (currentLine.EndsWith("."))
{
currentLine += currentWord;
}
else
currentLine += " " + currentWord;

if (currentWord.IndexOf(">") > -1)
InTag = false;
}
else
{
if (currentLineLength + currentWord.Length + 1 < maxLength)
{
currentLine += " " + currentWord;
currentLineLength += (currentWord.Length + 1);
}
else
{
Lines.Add(currentLine);
currentLine = currentWord;
currentLineLength = currentWord.Length;
}
}
}

}
if (currentLine != "")
Lines.Add(currentLine);

string[] textLinesStr = new string[Lines.Count];
Lines.CopyTo(textLinesStr, 0);
return textLinesStr;
}


	}
}
