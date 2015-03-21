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
using System.Linq;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongFileMapper : ISongFileMapper<PowerPraiseSong>
    {
        /// <summary>
        ///     Maps a PowerPraise song to a Song object
        /// </summary>
        /// <param name="ppl"></param>
        /// <returns></returns>
        public Song Map(PowerPraiseSong ppl)
        {
            var song = new Song
            {
                Title = ppl.Title,
                Language = ppl.Language
            };

            if (ppl.Category != PowerPraiseConstants.NoCategory)
            {
                song.Themes.Add(ppl.Category);
            }

            // Copyright text
            song.Copyright = String.Join(Environment.NewLine, ppl.CopyrightText.ToArray());
            switch (ppl.Formatting.CopyrightTextPosition)
            {
                case PowerPraiseSongFormatting.CopyrightPosition.FirstSlide:
                    song.CopyrightPosition = AdditionalInformationPosition.FirstSlide;
                    break;
                case PowerPraiseSongFormatting.CopyrightPosition.LastSlide:
                    song.CopyrightPosition = AdditionalInformationPosition.LastSlide;
                    break;
                case PowerPraiseSongFormatting.CopyrightPosition.None:
                    song.CopyrightPosition = AdditionalInformationPosition.None;
                    break;
            }

            // Source / songbook
            song.SongBooks.FromString(ppl.SourceText);
            song.SourcePosition = ppl.Formatting.SourceTextEnabled
                ? AdditionalInformationPosition.FirstSlide
                : AdditionalInformationPosition.None;

            // Song parts
            foreach (var prt in ppl.Parts)
            {
                var part = new SongPart
                {
                    Caption = prt.Caption
                };
                foreach (var sld in prt.Slides)
                {
                    var slide = new SongSlide();
                    if (sld.Background != null)
                    {
                        slide.Background = (IBackground)sld.Background.Clone();
                    }
                    slide.TextSize = sld.MainSize > 0
                        ? sld.MainSize
                        : (song.MainText.Font != null ? song.MainText.Font.Size : 0);
                    slide.Lines.AddRange(sld.Lines);
                    slide.Translation.AddRange(sld.Translation);
                    part.Slides.Add(slide);
                }
                song.Parts.Add(part);
            }

            // Order
            foreach (var o in ppl.Order)
            {
                foreach (var p in song.Parts)
                {
                    if (p.Caption == o.Caption)
                    {
                        song.PartSequence.Add(p);
                        break;
                    }
                }
            }

            MapFormatting(ppl, song);

            return song;
        }

        /// <summary>
        ///     Maps a song to a PowerPraise song object
        /// </summary>
        /// <param name="song"></param>
        /// <param name="ppl"></param>
        public void Map(Song song, PowerPraiseSong ppl)
        {
            // General
            ppl.Title = song.Title;
            ppl.Language = song.Language;
            ppl.Category = null;
            foreach (var th in song.Themes)
            {
                if (th != PowerPraiseConstants.NoCategory)
                {
                    ppl.Category = th;
                    break;
                }
            }

            // Song parts
            foreach (var songPart in song.Parts)
            {
                var pplPart = new PowerPraiseSong.Part
                {
                    Caption = songPart.Caption
                };
                foreach (var songSlide in songPart.Slides)
                {
                    var pplSlide = new PowerPraiseSong.Slide
                    {
                        Background = (IBackground) songSlide.Background.Clone(),
                        MainSize = (int)
                            (songSlide.TextSize > 0
                                ? songSlide.TextSize
                                : (song.MainText != null && song.MainText.Font != null ? song.MainText.Font.Size : 0))
                    };
                    pplSlide.Lines.AddRange(songSlide.Lines);
                    pplSlide.Translation.AddRange(songSlide.Translation);
                    pplPart.Slides.Add(pplSlide);
                }
                ppl.Parts.Add(pplPart);
            }

            // Part order
            if (song.PartSequence.Any())
            {
                foreach (var p in song.PartSequence)
                {
                    foreach (var t in ppl.Parts)
                    {
                        if (p.Caption == t.Caption)
                        {
                            ppl.Order.Add(t);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var t in ppl.Parts)
                {
                    ppl.Order.Add(t);
                }
            }

            // Copyright text
            ppl.CopyrightText.Add(song.Copyright);
            if (song.CopyrightPosition == AdditionalInformationPosition.FirstSlide)
            {
                ppl.Formatting.CopyrightTextPosition = PowerPraiseSongFormatting.CopyrightPosition.FirstSlide;
            }
            else if (song.CopyrightPosition == AdditionalInformationPosition.LastSlide)
            {
                ppl.Formatting.CopyrightTextPosition = PowerPraiseSongFormatting.CopyrightPosition.LastSlide;
            }
            else if (song.CopyrightPosition == AdditionalInformationPosition.None)
            {
                ppl.Formatting.CopyrightTextPosition = PowerPraiseSongFormatting.CopyrightPosition.None;
            }

            // Source / songbook
            ppl.SourceText = song.SongBooks.ToString();
            ppl.Formatting.SourceTextEnabled = (song.SourcePosition == AdditionalInformationPosition.FirstSlide);

            // Linespacing
            if (song.MainText != null)
            {
                ppl.Formatting.MainLineSpacing = song.MainText.LineSpacing;
                ppl.Formatting.TranslationLineSpacing = song.TranslationText.LineSpacing;
            }

            MapFormatting(song, ppl);
        }

        private void MapFormatting(PowerPraiseSong ppl, Song song)
        {
            // Formatting definitions
            song.MainText = new TextFormatting(
                ppl.Formatting.MainText.Font,
                ppl.Formatting.MainText.Color,
                new TextOutline(ppl.Formatting.MainText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.MainText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color),
                ppl.Formatting.MainLineSpacing
                );
            song.TranslationText = new TextFormatting(
                ppl.Formatting.TranslationText.Font,
                ppl.Formatting.TranslationText.Color,
                new TextOutline(ppl.Formatting.TranslationText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.TranslationText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color),
                ppl.Formatting.TranslationLineSpacing
                );
            song.CopyrightText = new TextFormatting(
                ppl.Formatting.CopyrightText.Font,
                ppl.Formatting.CopyrightText.Color,
                new TextOutline(ppl.Formatting.CopyrightText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.CopyrightText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color),
                0
                );
            song.SourceText = new TextFormatting(
                ppl.Formatting.SourceText.Font,
                ppl.Formatting.SourceText.Color,
                new TextOutline(ppl.Formatting.SourceText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.SourceText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color),
                0
                );

            // Text orientation
            song.TextOrientation = ppl.Formatting.TextOrientation;
            song.TranslationPosition = ppl.Formatting.TranslationPosition;

            // Enable or disable outline/shadow
            song.TextOutlineEnabled = ppl.Formatting.Outline.Enabled;
            song.TextShadowEnabled = ppl.Formatting.Shadow.Enabled;

            // Borders
            song.TextBorders = new SongTextBorders(
                ppl.Formatting.Borders.TextLeft,
                ppl.Formatting.Borders.TextTop,
                ppl.Formatting.Borders.TextRight,
                ppl.Formatting.Borders.TextBottom,
                ppl.Formatting.Borders.CopyrightBottom,
                ppl.Formatting.Borders.SourceTop,
                ppl.Formatting.Borders.SourceRight
                );
        }

        private void MapFormatting(Song song, PowerPraiseSong ppl)
        {
            // Formatting definitions
            if (song.MainText != null)
            {
                ppl.Formatting.MainText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.MainText.Font,
                    Color = song.MainText.Color,
                    OutlineWidth = song.MainText.Outline.Width,
                    ShadowDistance = song.MainText.Shadow.Distance
                };
            }
            if (song.TranslationText != null)
            {
                ppl.Formatting.TranslationText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.TranslationText.Font,
                    Color = song.TranslationText.Color,
                    OutlineWidth = song.TranslationText.Outline.Width,
                    ShadowDistance = song.TranslationText.Shadow.Distance
                };
            }
            if (song.CopyrightText != null)
            {
                ppl.Formatting.CopyrightText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.CopyrightText.Font,
                    Color = song.CopyrightText.Color,
                    OutlineWidth = song.CopyrightText.Outline.Width,
                    ShadowDistance = song.CopyrightText.Shadow.Distance
                };
            }
            if (song.SourceText != null)
            {
                ppl.Formatting.SourceText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.SourceText.Font,
                    Color = song.SourceText.Color,
                    OutlineWidth = song.SourceText.Outline.Width,
                    ShadowDistance = song.SourceText.Shadow.Distance
                };
            }

            // Enable or disable outline/shadow
            if (song.MainText != null)
            {
                ppl.Formatting.Outline = new PowerPraiseSongFormatting.OutlineFormatting
                {
                    Color = song.MainText.Outline.Color,
                    Enabled = song.TextOutlineEnabled
                };
                ppl.Formatting.Shadow = new PowerPraiseSongFormatting.ShadowFormatting
                {
                    Color = song.MainText.Shadow.Color,
                    Direction = song.MainText.Shadow.Direction,
                    Enabled = song.TextShadowEnabled
                };
            }

            // Text orientation
            ppl.Formatting.TextOrientation = song.TextOrientation;
            ppl.Formatting.TranslationPosition = song.TranslationPosition;

            // Borders
            if (song.TextBorders != null)
            {
                ppl.Formatting.Borders = new PowerPraiseSongFormatting.TextBorders
                {
                    TextLeft = song.TextBorders.TextLeft,
                    TextTop = song.TextBorders.TextTop,
                    TextRight = song.TextBorders.TextRight,
                    TextBottom = song.TextBorders.TextBottom,
                    CopyrightBottom = song.TextBorders.CopyrightBottom,
                    SourceTop = song.TextBorders.SourceTop,
                    SourceRight = song.TextBorders.SourceRight
                };
            }
        }
    }
}