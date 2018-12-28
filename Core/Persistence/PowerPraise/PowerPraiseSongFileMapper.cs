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
            song.Copyright = string.Join(Environment.NewLine, ppl.CopyrightText.ToArray());
            song.Formatting = new SongFormatting();
            song.Formatting.CopyrightPosition = ppl.Formatting.CopyrightTextPosition;

            // Source / songbook
            song.SongBooks.FromString(ppl.SourceText);
            song.Formatting.SongBookPosition = ppl.Formatting.SourceTextPosition;

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
                        slide.Background = (IBackground) sld.Background.Clone();
                    }
                    slide.TextSize = sld.MainSize > 0
                        ? sld.MainSize
                        : (song.Formatting.MainText.Font != null ? song.Formatting.MainText.Font.Size : 0);
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
                        Background = songSlide.Background != null ? (IBackground) songSlide.Background.Clone() : null,
                        MainSize = (int)
                            (songSlide.TextSize > 0
                                ? songSlide.TextSize
                                : (song.Formatting != null && song.Formatting.MainText != null && song.Formatting.MainText.Font != null
                                    ? song.Formatting.MainText.Font.Size
                                    : 0))
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
            if (song.Copyright != null)
            {
                foreach (var s in song.Copyright.Split(new[] {Environment.NewLine}, StringSplitOptions.None))
                {
                    ppl.CopyrightText.Add(s);
                }
            }
            ppl.Formatting.CopyrightTextPosition = song.Formatting.CopyrightPosition;

            // Source / songbook
            ppl.SourceText = song.SongBooks.ToString();
            ppl.Formatting.SourceTextPosition = song.Formatting.SongBookPosition;

            // Linespacing
            if (song.Formatting.MainText != null)
            {
                ppl.Formatting.MainLineSpacing = song.Formatting.MainLineSpacing;
                ppl.Formatting.TranslationLineSpacing = song.Formatting.TranslationLineSpacing;
            }

            MapFormatting(song, ppl);
        }

        private void MapFormatting(PowerPraiseSong ppl, Song song)
        {
            // Formatting definitions
            song.Formatting.MainText = new TextFormatting(
                ppl.Formatting.MainText.Font,
                ppl.Formatting.MainText.Color,
                new TextOutline(ppl.Formatting.MainText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.MainText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color)
                );
            song.Formatting.TranslationText = new TextFormatting(
                ppl.Formatting.TranslationText.Font,
                ppl.Formatting.TranslationText.Color,
                new TextOutline(ppl.Formatting.TranslationText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.TranslationText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color)
                );
            song.Formatting.CopyrightText = new TextFormatting(
                ppl.Formatting.CopyrightText.Font,
                ppl.Formatting.CopyrightText.Color,
                new TextOutline(ppl.Formatting.CopyrightText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.CopyrightText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color)
                );
            song.Formatting.SourceText = new TextFormatting(
                ppl.Formatting.SourceText.Font,
                ppl.Formatting.SourceText.Color,
                new TextOutline(ppl.Formatting.SourceText.OutlineWidth, ppl.Formatting.Outline.Color),
                new TextShadow(ppl.Formatting.SourceText.ShadowDistance, 0, ppl.Formatting.Shadow.Direction,
                    ppl.Formatting.Shadow.Color)
                );

            // Line spacing
            song.Formatting.MainLineSpacing = ppl.Formatting.MainLineSpacing;
            song.Formatting.TranslationLineSpacing = ppl.Formatting.TranslationLineSpacing;

            // Text orientation
            song.Formatting.TextOrientation = ppl.Formatting.TextOrientation;
            song.Formatting.TranslationPosition = ppl.Formatting.TranslationPosition;

            // Enable or disable outline/shadow
            song.Formatting.TextOutlineEnabled = ppl.Formatting.Outline.Enabled;
            song.Formatting.TextShadowEnabled = ppl.Formatting.Shadow.Enabled;

            // Borders
            song.Formatting.TextBorders = new SongTextBorders(
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
            if (song.Formatting.MainText != null)
            {
                ppl.Formatting.MainText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.Formatting.MainText.Font,
                    Color = song.Formatting.MainText.Color,
                    OutlineWidth = song.Formatting.MainText.Outline.Width,
                    ShadowDistance = song.Formatting.MainText.Shadow.Distance
                };
            }
            if (song.Formatting.TranslationText != null)
            {
                ppl.Formatting.TranslationText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.Formatting.TranslationText.Font,
                    Color = song.Formatting.TranslationText.Color,
                    OutlineWidth = song.Formatting.TranslationText.Outline.Width,
                    ShadowDistance = song.Formatting.TranslationText.Shadow.Distance
                };
            }
            if (song.Formatting.CopyrightText != null)
            {
                ppl.Formatting.CopyrightText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.Formatting.CopyrightText.Font,
                    Color = song.Formatting.CopyrightText.Color,
                    OutlineWidth = song.Formatting.CopyrightText.Outline.Width,
                    ShadowDistance = song.Formatting.CopyrightText.Shadow.Distance
                };
            }
            if (song.Formatting.SourceText != null)
            {
                ppl.Formatting.SourceText = new PowerPraiseSongFormatting.FontFormatting
                {
                    Font = song.Formatting.SourceText.Font,
                    Color = song.Formatting.SourceText.Color,
                    OutlineWidth = song.Formatting.SourceText.Outline.Width,
                    ShadowDistance = song.Formatting.SourceText.Shadow.Distance
                };
            }

            // Enable or disable outline/shadow
            if (song.Formatting.MainText != null)
            {
                ppl.Formatting.Outline = new PowerPraiseSongFormatting.OutlineFormatting
                {
                    Color = song.Formatting.MainText.Outline.Color,
                    Enabled = song.Formatting.TextOutlineEnabled
                };
                ppl.Formatting.Shadow = new PowerPraiseSongFormatting.ShadowFormatting
                {
                    Color = song.Formatting.MainText.Shadow.Color,
                    Direction = song.Formatting.MainText.Shadow.Direction,
                    Enabled = song.Formatting.TextShadowEnabled
                };
            }

            // Text orientation
            ppl.Formatting.TextOrientation = song.Formatting.TextOrientation;
            ppl.Formatting.TranslationPosition = song.Formatting.TranslationPosition;

            // Borders
            if (song.Formatting.TextBorders != null)
            {
                ppl.Formatting.Borders = new PowerPraiseSongFormatting.TextBorders
                {
                    TextLeft = song.Formatting.TextBorders.TextLeft,
                    TextTop = song.Formatting.TextBorders.TextTop,
                    TextRight = song.Formatting.TextBorders.TextRight,
                    TextBottom = song.Formatting.TextBorders.TextBottom,
                    CopyrightBottom = song.Formatting.TextBorders.CopyrightBottom,
                    SourceTop = song.Formatting.TextBorders.SourceTop,
                    SourceRight = song.Formatting.TextBorders.SourceRight
                };
            }
        }
    }
}