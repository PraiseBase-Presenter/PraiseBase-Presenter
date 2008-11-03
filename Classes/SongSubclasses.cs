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
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using Pbp.Properties; 

namespace Pbp
{
	public partial class Song
	{
		#region Enums and structs

		/// <summary>
		/// Horizontal aligning of slide text
		/// </summary>
		public enum SongTextHorizontalAlign
		{
			/// <summary>
			/// Text is aligned horizontally to the left
			/// </summary>
			left,
			/// <summary>
			/// Text is horizontally centered
			/// </summary>
			center,
			/// <summary>
			/// Text is aligned horizontally to the right
			/// </summary>
			right
		}

		/// <summary>
		/// Vertical aligning of slide text
		/// </summary>
		public enum SongTextVerticalAlign
		{
			/// <summary>
			/// Text is aligned vertically to the top of the page
			/// </summary>
			top,
			/// <summary>
			/// Text is aligned to the center
			/// </summary>
			center,
			/// <summary>
			/// Text is aligned vertically to the bottom of the page
			/// </summary>
			bottom
		}

		/// <summary>
		/// Different flags for indicating problems with the song 
		/// whichs needs to be revised
		/// </summary>
		public enum QualityAssuranceItem
		{
			/// <summary>
			/// Indicates wether spelling of the songtext is incorrect
			/// </summary>
			spelling = 1,
			/// <summary>
			/// Indicates wether images are broken or incomplete
			/// </summary>
			images = 2,
			/// <summary>
			/// Indicates wether the translation is missing or incomplete
			/// </summary>
			translation = 4,
			/// <summary>
			/// Indicates wether the layout of the slides needs optimization
			/// </summary>
			segmentation = 8
		}

		#endregion

		/// <summary>
		/// Tag class. It allows only unique items
		/// </summary>
		public class Tags : List<string>
		{
			/// <summary>
			/// Adds an unique tag to the taglist
			/// </summary>
			/// <param name="tagName"></param>
			public new void Add(string tagName)
			{
				if (!Contains(tagName))
				{
					base.Add(tagName);
				}
			}

			/// <summary>
			/// Returns a comma separated string of all tags
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				string res = string.Empty;
				for (int i = 0; i < this.Count; i++)
				{
					res += this.ElementAt(i);
					if (i < this.Count - 1)
						res += ", ";
				}
				return res;
			}
		}

		/// <summary>
		/// A song part with a given name and one or more slides
		/// </summary>
		public class Part
		{
			/// <summary>
			/// Song part name like chorus, bridge, part 1 ...
			/// </summary>
			public string caption;
			/// <summary>
			/// A list of containing slides. Each part has one slide at minimum
			/// </summary>
			public List<Slide> slides;

			/// <summary>
			/// Part constructor
			/// </summary>
			public Part(string caption)
			{
				slides = new List<Slide>();
				if (caption != null && caption != String.Empty)
					this.caption = caption;
				else
					this.caption = "Neuer Liedteil";
			}

			/// <summary>
			/// Swaps the given slide with it's predecessor
			/// </summary>
			/// <param name="slideId">The slide index</param>
			/// <returns>Returns true is swapping was successfull</returns>
			public bool swapSlideWithUpperSlide(int slideId)
			{
				if (slideId > 0 && slideId < slides.Count)
				{
					Slide tmpPrt = slides[slideId - 1];
					slides.RemoveAt(slideId - 1);
					slides.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			/// <summary>
			/// Swaps the given slide with it's successor
			/// </summary>
			/// <param name="slideId">The slide index</param>
			/// <returns>Returns true is swapping was successfull</returns>
			public bool swapSlideWithLowerSlide(int slideId)
			{
				if (slideId >= 0 && slideId < slides.Count - 1)
				{
					Slide tmpPrt = slides[slideId + 1];
					slides.RemoveAt(slideId + 1);
					slides.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			/// <summary>
			/// Duplicates a given slide
			/// </summary>
			/// <param name="slideId">The slide index</param>
			public void duplicateSlide(int slideId)
			{
				slides.Insert(slideId, (Slide)slides[slideId].Clone());
			}

			/// <summary>
			/// Duplicates a slide and cuts it's text in half,
			/// assigning the first part to the original slide
			/// and the second part to the copy
			/// </summary>
			/// <param name="slideId">The slide index</param>
			public void splitSlide(int slideId)
			{
				Slide sld = (Slide)slides[slideId].Clone();

				int totl = sld.lines.Count;
				int rem = totl / 2;
				slides[slideId].lines.RemoveRange(0, rem);
				sld.lines.RemoveRange(rem, totl - rem);

				totl = sld.translation.Count;
				rem = totl / 2;
				slides[slideId].translation.RemoveRange(0, rem);
				sld.translation.RemoveRange(rem, totl - rem);

				slides.Insert(slideId, sld);
			}
		};

		/// <summary>
		/// A single slide with songtext and/or a background image
		/// </summary>
		public class Slide : ICloneable
		{
			/// <summary>
			/// Pointer to the song object who owns this slide
			/// </summary>
			private Song ownerSong;
			/// <summary>
			/// All text lines of this slide
			/// </summary>
			public List<string> lines;
			/// <summary>
			/// All translation lines of this slide
			/// </summary>
			public List<string> translation;
			/// <summary>
			/// Number of the slide image. If set to -1, no image is used
			/// </summary>
			public int imageNumber;
			/// <summary>
			/// Path to the slides image
			/// </summary>
			public string image;
			/// <summary>
			/// Indicates wether this slide has a translation
			/// </summary>
			public bool hasTranslation;
			/// <summary>
			/// Horizonztal text alignment
			/// </summary>
			public SongTextHorizontalAlign horizAlign;
			/// <summary>
			/// Vertical text alignment
			/// </summary>
			public SongTextVerticalAlign vertAlign;
			/// <summary>
			/// The font object of this slide
			/// </summary>
			public Font font { get { return ownerSong.font; } }
			/// <summary>
			/// The font object of the translation
			/// </summary>
			public Font fontTranslation { get { return ownerSong.fontTranslation; } }
			/// <summary>
			/// The font color of this slide
			/// </summary>
			public Color fontColor { get { return ownerSong.fontColor; } }
			/// <summary>
			/// The translation font color
			/// </summary>
			public Color fontColorTranslation { get { return ownerSong.fontColorTranslation; } }
			/// <summary>
			/// The line spacing of the text
			/// </summary>
			public int lineSpacint { get { return ownerSong.lineSpacing; } }

			/// <summary>
			/// The slide constructor
			/// </summary>
			public Slide(Song ownerSong)
			{
				lines = new List<string>();
				translation = new List<string>();
				hasTranslation = false;
				horizAlign = SongTextHorizontalAlign.center;
				vertAlign = SongTextVerticalAlign.center;
				this.ownerSong = ownerSong;
			}

			/// <summary>
			/// Sets the text of this slide
			/// </summary>
			/// <param name="text"></param>
			public void setSlideText(string text)
			{
				this.lines = new List<string>();
				string[] ln = text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in ln)
				{
					this.lines.Add(sl.Trim());
				}
			}

			/// <summary>
			/// Sets the translation of this slide
			/// </summary>
			/// <param name="text"></param>
			public void setSlideTextTranslation(string text)
			{
				this.translation = new List<string>();
				string[] tr = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in tr)
				{
					this.translation.Add(sl.Trim());
				}
			}

			/// <summary>
			/// Returns a string of the wrapped text
			/// </summary>
			/// <returns>Wrapped text</returns>
			public string lineBreakText()
			{
				string txt = "";
				int i = 1;
				foreach (string str in lines)
				{
					txt += str;
					if (i<lines.Count)
						txt += Environment.NewLine;
					i++;
				}
				return txt;

			}

			/// <summary>
			/// Returns the wrapped translation text
			/// </summary>
			/// <returns>Wrapped translation</returns>
			public string lineBreakTranslation()
			{
				string txt = "";
				int i = 1;
				foreach (string str in translation)
				{
					txt += str;
					if (i<translation.Count)
						txt += Environment.NewLine;
					i++;
				}
				return txt;

			}

			/// <summary>
			/// Returns the text on one line. This is mainly used 
			/// in the song detail overview in the presenter.
			/// </summary>
			/// <returns>Text on one line</returns>
			public string oneLineText()
			{
				string txt = "";
				foreach (string str in lines)
				{
					txt += str + " ";
				}
				return txt;
			}

			/// <summary>
			/// Clones this slide
			/// </summary>
			/// <returns>A duplicate of this slide</returns>
			public object Clone()
			{
				Slide res = new Slide(this.ownerSong);
				res.hasTranslation = hasTranslation;
				res.horizAlign = horizAlign;
				res.imageNumber = imageNumber;
				foreach (string obj in lines)
					res.lines.Add(obj);
				foreach (string obj in translation)
					res.translation.Add(obj);
				res.vertAlign = vertAlign;
				return res;
			}

		};

		public abstract class fileType
		{
			static public fileType createFactory(string ext, string version)
			{
				if (ext == fileTypePBPS.extension && version == fileTypePBPS.version)
				{
					return new fileTypePBPS();
				}
				else if (ext == fileTypePPL.extension && version == fileTypePPL.version)
				{
					return new fileTypePPL();
				}
				return null;
			}

			static public fileType createFactory(string ext)
			{
				if (ext == fileTypePBPS.extension || ext == "." + fileTypePBPS.extension)
				{
					return new fileTypePBPS();
				}
				else if (ext == fileTypePPL.extension || ext == "." + fileTypePPL.extension)
				{
					return new fileTypePPL();
				}
				return null;
			}

			public static string getFilter()
			{
				String fltr = String.Empty;
				//fltr += fileTypePBPS.name + " (*." + fileTypePBPS.extension + ")|*." + fileTypePBPS.extension + "|";
				fltr += fileTypePPL.name + " (*." + fileTypePPL.extension + ")|*." + fileTypePPL.extension + "|";
				fltr += "Alle Dateien (*.*)|*.*";
				return fltr;
			}

			public static string getFilterSave()
			{
				String fltr = String.Empty;
				//fltr += fileTypePBPS.name + " (*." + fileTypePBPS.extension + ")|*." + fileTypePBPS.extension + "|";
				fltr += fileTypePPL.name + " (*." + fileTypePPL.extension + ")|*." + fileTypePPL.extension + "";
				return fltr;
			}


			public static string[] getAllExtensions()
			{
				return new string[] { 
					"*."+fileTypePBPS.extension, 
					"*."+fileTypePPL.extension };
			}
		}

		protected class fileTypePBPS : fileType
		{
			static public string name = "PraiseBase-Presenter Song";
			static public string extension = "pbps";
			static public string version = "1.0";
			static public bool isDefault = true;
		}

		protected class fileTypePPL : fileType
		{
			static public string name = "PowerPraise Lied (veraltet)";
			static public string extension = "ppl";
			static public string version = "3.0";
			static public bool isDefault = false;
		}

	}
}
