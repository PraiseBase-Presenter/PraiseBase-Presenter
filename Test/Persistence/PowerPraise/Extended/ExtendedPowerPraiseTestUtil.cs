using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    static class ExtendedPowerPraiseTestUtil
    {
        public static ExtendedPowerPraiseSong GetExpectedExtendedPowerPraiseSong()
        {
            ExtendedPowerPraiseSong ppl = new ExtendedPowerPraiseSong();

            // General
            ppl.Title = "Näher, mein Gott, zu Dir";
            ppl.Language = "Deutsch";
            ppl.Category = "Anbetung";

            ppl.Comment = "Test";
            ppl.GUID = new Guid("78dd30b2-078b-4eef-9767-dc41a6e6ab27");
            ppl.QualityIssues.Add(SongQualityAssuranceIndicator.Translation);
            ppl.QualityIssues.Add(SongQualityAssuranceIndicator.Segmentation);
            ppl.CcliID = "12123";
            SongAuthor a = new SongAuthor();
            a.Name = "asd as d";
            ppl.Author.Add(a);
            ppl.Publisher = "Sparrow Records";
            ppl.RightsManagement = "Verlag ABC";

            // Songtext
            PowerPraiseSongPart part = new PowerPraiseSongPart();
            part.Caption = "Teil 1";

            PowerPraiseSongSlide slide = new PowerPraiseSongSlide();
            slide.MainSize = 42;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Näher, mein Gott, zu Dir,");
            slide.Lines.Add("sei meine Bitt'!");
            slide.Lines.Add("Näher, o Herr, zu Dir");
            slide.Lines.Add("mit jedem Schritt.");
            part.Slides.Add(slide);

            slide = new PowerPraiseSongSlide();
            slide.MainSize = 44;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Nur an dem Herzen Dein");
            slide.Lines.Add("kann ich geborgen sein;");
            slide.Lines.Add("deshalb die Bitte mein:");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            ppl.Parts.Add(part);

            part = new PowerPraiseSongPart();
            part.Caption = "Teil 2";

            slide = new PowerPraiseSongSlide();
            slide.MainSize = 42;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Ein jeder Tag");
            slide.Lines.Add("soll es neu zeigen mir,");
            slide.Lines.Add("was er vermag:");
            part.Slides.Add(slide);

            slide = new PowerPraiseSongSlide();
            slide.MainSize = 42;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Wie seiner Gnade Macht,");
            slide.Lines.Add("Erlösung hat gebracht,");
            slide.Lines.Add("in uns're Sündennacht.");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            ppl.Parts.Add(part);

            part = new PowerPraiseSongPart();
            part.Caption = "Teil 3";

            slide = new PowerPraiseSongSlide();
            slide.MainSize = 42;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Dich bet' ich an.");
            slide.Lines.Add("Wie vieles hast an mir,");
            slide.Lines.Add("Du doch getan!");
            part.Slides.Add(slide);

            slide = new PowerPraiseSongSlide();
            slide.MainSize = 42;
            slide.BackgroundNr = 0;
            slide.Lines.Add("Von Banden frei und los,");
            slide.Lines.Add("ruh' ich in Deinem Schoss.");
            slide.Lines.Add("Ja, Deine Gnad' ist gross!");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            ppl.Parts.Add(part);

            // Order
            ppl.Order.Add(ppl.Parts[0]);
            ppl.Order.Add(ppl.Parts[1]);
            ppl.Order.Add(ppl.Parts[2]);

            // Copyright
            ppl.CopyrightText.Add("Text und Musik: Lowell Mason, 1792-1872");
            ppl.CopyrightTextPosition = PowerPraiseSong.CopyrightPosition.LastSlide;

            // Source
            ppl.SourceText = "grünes Buch 339";
            ppl.SourceTextEnabled = true;

            // Formatting
            ppl.MainTextFontFormatting = new PowerPraiseSong.FontFormatting
            {
                Font = new Font("Times New Roman", 44, FontStyle.Bold | FontStyle.Italic),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 15
            };
            ppl.TranslationTextFontFormatting = new PowerPraiseSong.FontFormatting
            {
                Font = new Font("Times New Roman", 20, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.CopyrightTextFontFormatting = new PowerPraiseSong.FontFormatting
            {
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.SourceTextFontFormatting = new PowerPraiseSong.FontFormatting
            {
                Font = new Font("Times New Roman", 30, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.TextOutlineFormatting = new PowerPraiseSong.OutlineFormatting
            {
                Color = Color.Black,
                Enabled = false
            };
            ppl.TextShadowFormatting = new PowerPraiseSong.ShadowFormatting
            {
                Color = Color.Black,
                Direction = 125,
                Enabled = true
            };

            // Background
            ppl.BackgroundImages.Add("Blumen\\Blume 3.jpg");

            // Line spacing
            ppl.MainLineSpacing = 30;
            ppl.TranslationLineSpacing = 20;

            // Text orientation
            ppl.TextOrientation = new Model.TextOrientation(Model.VerticalOrientation.Middle, Model.HorizontalOrientation.Left);
            ppl.TranslationTextPosition = TranslationPosition.Inline;

            // Borders
            ppl.Borders = new PowerPraiseSong.TextBorders
            {
                TextLeft = 50,
                TextTop = 40,
                TextRight = 60,
                TextBottom = 70,
                CopyrightBottom = 30,
                SourceTop = 20,
                SourceRight = 40
            };

            return ppl;
        }

        public static Song GetExpectedSongExtended()
        {
            Song song = PowerPraiseTestUtil.GetExpectedSong();

            song.Comment = "Test";
            song.Guid = new Guid("78dd30b2-078b-4eef-9767-dc41a6e6ab27");
            song.QualityIssues.Add(SongQualityAssuranceIndicator.Translation);
            song.QualityIssues.Add(SongQualityAssuranceIndicator.Segmentation);
            song.CcliIdentifier = "12123";
            SongAuthor a = new SongAuthor();
            a.Name = "asd as d";
            song.Author.Add(a);
            song.Publisher = "Sparrow Records";
            song.RightsManagement = "Verlag ABC";

            return song;
        }
    }
}
