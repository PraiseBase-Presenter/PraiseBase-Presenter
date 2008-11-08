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
		#region Enums

		/// <summary>
		/// Horizontal aligning of slide text
		/// </summary>
		public enum SongTextHorizontalAlign
		{
			/// <summary>
			/// Text is aligned horizontally to the left
			/// </summary>
			Left,
			/// <summary>
			/// Text is horizontally centered
			/// </summary>
			Center,
			/// <summary>
			/// Text is aligned horizontally to the right
			/// </summary>
			Right
		}

		/// <summary>
		/// Vertical aligning of slide text
		/// </summary>
		public enum SongTextVerticalAlign
		{
			/// <summary>
			/// Text is aligned vertically to the top of the page
			/// </summary>
			Top,
			/// <summary>
			/// Text is aligned to the center
			/// </summary>
			Center,
			/// <summary>
			/// Text is aligned vertically to the bottom of the page
			/// </summary>
			Bottom
		}

		/// <summary>
		/// Different flags for indicating problems with the song 
		/// whichs needs to be revised
		/// </summary>
		public enum QualityAssuranceIndicators
		{
			/// <summary>
			/// Indicates wether spelling of the songtext is incorrect
			/// </summary>
			Spelling = 1,
			/// <summary>
			/// Indicates wether images are broken or incomplete
			/// </summary>
			Images = 2,
			/// <summary>
			/// Indicates wether the translation is missing or incomplete
			/// </summary>
			Translation = 4,
			/// <summary>
			/// Indicates wether the layout of the slides needs optimization
			/// </summary>
			Segmentation = 8
		}

		/// <summary>
		/// Available song filetypes
		/// </summary>
		public enum FileFormat
		{
			/// <summary>
			/// Powerpraise song file format (deprecated)
			/// </summary>
			ppl,
			/// <summary>
			/// Default PBP file format
			/// </summary>
			pbps,
			/// <summary>
			/// Invalid file type
			/// </summary>
			invalid
		}

		#endregion

		#region Subclasses

		/// <summary>
		/// Tag class. It allows only unique items
		/// </summary>
		public class TagList : List<string>
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
			public string Caption {get;set;}
			/// <summary>
			/// A list of containing slides. Each part has one slide at minimum
			/// </summary>
			public SlideList Slides { get; set; }

			/// <summary>
			/// Part constructor
			/// </summary>
			public Part() : this("Neuer Liedteil")
			{
			}

			/// <summary>
			/// Part constructor
			/// </summary>
			/// <param name="caption">The part's caption</param>
			public Part(string caption)
			{
				Slides = new SlideList();
				Caption = caption;
			}

			public override int GetHashCode()
			{
				return Caption.GetHashCode() ^ Slides.GetHashCode();
			}

		};

		/// <summary>
		/// Provides a list of all parts in the song
		/// </summary>
		public class PartList : List<Part>
		{
			/// <summary>
			/// Swaps the part with the previous one
			/// </summary>
			/// <param name="partId">Index of the part</param>
			/// <returns></returns>
			public bool swapWithUpper(int partId)
			{
				if (partId > 0 && partId < this.Count)
				{
					Part tmpPrt = this[partId - 1];
					this.RemoveAt(partId - 1);
					this.Insert(partId, tmpPrt);
					return true;
				}
				return false;
			}
			
			/// <summary>
			/// Swaps the part with the next one
			/// </summary>
			/// <param name="partId">Index of the part</param>
			/// <returns></returns>
			public bool swapWithLower(int partId)
			{
				if (partId >= 0 && partId < this.Count - 1)
				{
					Part tmpPrt = this[partId + 1];
					this.RemoveAt(partId + 1);
					this.Insert(partId, tmpPrt);
					return true;
				}
				return false;
			}

			public override int GetHashCode()
			{
				int res = 0;
				for (int i = 0; i < Count; i++)
				{
					res = (res ^ this[i].GetHashCode()) ^ i.GetHashCode(); 
				}
				return res;
			}
		}

		/// <summary>
		/// A single slide with songtext and/or a background image
		/// </summary>
		public class Slide : ICloneable
		{
			/// <summary>
			/// Pointer to the song object who owns this slide
			/// </summary>
			private Song _ownerSong;

			/// <summary>
			/// All text lines of this slide
			/// </summary>
			public List<string> Lines { get; set; }
			/// <summary>
			/// All translation lines of this slide
			/// </summary>
			public List<string> Translation { get; set; }
			/// <summary>
			/// Number of the slide image. If set to -1, no image is used
			/// </summary>
			public int ImageNumber { get; set; }
			/// <summary>
			/// Indicates wether this slide has a translation
			/// </summary>
			public bool Translated { get { return Translation.Count > 0 ? true : false; } }
			/// <summary>
			/// Horizonztal text alignment
			/// </summary>
			public SongTextHorizontalAlign HorizontalAlign {get;set;}
			/// <summary>
			/// Vertical text alignment
			/// </summary>
			public SongTextVerticalAlign VerticalAlign { get; set; }
			/// <summary>
			/// The font object of this slide
			/// </summary>
			public Font TextFont { get { return _ownerSong.TextFont; } }
			/// <summary>
			/// The font object of the translation
			/// </summary>
			public Font TranslationFont { get { return _ownerSong.TranslationFont; } }
			/// <summary>
			/// The font color of this slide
			/// </summary>
			public Color TextColor { get { return _ownerSong.TextColor; } }
			/// <summary>
			/// The translation font color
			/// </summary>
			public Color TranslationColor { get { return _ownerSong.TranslationColor; } }
			/// <summary>
			/// The line spacing of the text
			/// </summary>
			public int TextLineSpacing { get { return _ownerSong.TextLineSpacing; } }

			/// <summary>
			/// The slide constructor
			/// </summary>
			public Slide(Song ownerSong)
			{
				Lines = new List<string>();
				Translation = new List<string>();
				HorizontalAlign = SongTextHorizontalAlign.Center;
				VerticalAlign = SongTextVerticalAlign.Center;
				this._ownerSong = ownerSong;
			}

			/// <summary>
			/// Sets the text of this slide
			/// </summary>
			/// <param name="text"></param>
			public void setSlideText(string text)
			{
				this.Lines = new List<string>();
				string[] ln = text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in ln)
				{
					this.Lines.Add(sl.Trim());
				}
			}

			/// <summary>
			/// Sets the translation of this slide
			/// </summary>
			/// <param name="text"></param>
			public void setSlideTextTranslation(string text)
			{
				this.Translation = new List<string>();
				string[] tr = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in tr)
				{
					this.Translation.Add(sl.Trim());
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
				foreach (string str in Lines)
				{
					txt += str;
					if (i<Lines.Count)
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
				foreach (string str in Translation)
				{
					txt += str;
					if (i<Translation.Count)
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
				foreach (string str in Lines)
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
				Slide res = new Slide(this._ownerSong);
				res.HorizontalAlign = HorizontalAlign;
				res.ImageNumber = ImageNumber;
				foreach (string obj in Lines)
					res.Lines.Add(obj);
				foreach (string obj in Translation)
					res.Translation.Add(obj);
				res.VerticalAlign = VerticalAlign;
				return res;
			}

			public override int GetHashCode()
			{
				int res = ImageNumber.GetHashCode() ^ HorizontalAlign.GetHashCode() ^VerticalAlign.GetHashCode();
				for (int i = 0; i < Lines.Count; i++)
				{
					res = res ^ Lines[i].GetHashCode();
				}
				for (int i = 0; i < Translation.Count; i++)
				{
					res = res ^ Translation[i].GetHashCode();
				}
				return res;
			}

		};

		/// <summary>
		/// Provides a list of all slides
		/// </summary>
		public class SlideList : List<Slide>
		{
			/// <summary>
			/// Swaps the given slide with it's predecessor
			/// </summary>
			/// <param name="slideId">The slide index</param>
			/// <returns>Returns true is swapping was successfull</returns>
			public bool swapWithUpper(int slideId)
			{
				if (slideId > 0 && slideId < this.Count)
				{
					Slide tmpPrt = this[slideId - 1];
					this.RemoveAt(slideId - 1);
					this.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			/// <summary>
			/// Swaps the given slide with it's successor
			/// </summary>
			/// <param name="slideId">The slide index</param>
			/// <returns>Returns true is swapping was successfull</returns>
			public bool swapWithLower(int slideId)
			{
				if (slideId >= 0 && slideId < this.Count - 1)
				{
					Slide tmpPrt = this[slideId + 1];
					this.RemoveAt(slideId + 1);
					this.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			/// <summary>
			/// Duplicates a given slide
			/// </summary>
			/// <param name="slideId">The slide index</param>
			public void duplicate(int slideId)
			{
				this.Insert(slideId, (Slide)this[slideId].Clone());
			}

			/// <summary>
			/// Duplicates a slide and cuts it's text in half,
			/// assigning the first part to the original slide
			/// and the second part to the copy
			/// </summary>
			/// <param name="slideId">The slide index</param>
			public void split(int slideId)
			{
				Slide sld = (Slide)this[slideId].Clone();

				int totl = sld.Lines.Count;
				int rem = totl / 2;
				this[slideId].Lines.RemoveRange(0, rem);
				sld.Lines.RemoveRange(rem, totl - rem);

				totl = sld.Translation.Count;
				rem = totl / 2;
				this[slideId].Translation.RemoveRange(0, rem);
				sld.Translation.RemoveRange(rem, totl - rem);

				this.Insert(slideId, sld);
			}

			/// <summary>
			/// Returns the slidelist's hashcode
			/// </summary>
			/// <returns></returns>
			public override int GetHashCode()
			{
				int res = 0;
				for (int i = 0; i < Count; i++)
				{
					res = (res ^ this[i].GetHashCode()) ^ i.GetHashCode();
				}
				return res;
			}
		}

		#endregion

	}
}
