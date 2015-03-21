using System;
using System.Drawing;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    static class ExtendedPowerPraiseTestUtil
    {
        public static ExtendedPowerPraiseSong GetExpectedExtendedPowerPraiseSong()
        {
            ExtendedPowerPraiseSong ppl = new ExtendedPowerPraiseSong
            {
                Title = "Näher, mein Gott, zu Dir",
                Language = "Deutsch",
                Category = "Anbetung",
                Comment = "Test",
                Guid = new Guid("78dd30b2-078b-4eef-9767-dc41a6e6ab27")
            };

            // General

            ppl.QualityIssues.Add(SongQualityAssuranceIndicator.Translation);
            ppl.QualityIssues.Add(SongQualityAssuranceIndicator.Segmentation);
            ppl.CcliIdentifier = "12123";
            SongAuthor a = new SongAuthor
            {
                Name = "asd as d"
            };
            ppl.Author.Add(a);
            ppl.Publisher = "Sparrow Records";
            ppl.RightsManagement = "Verlag ABC";

            // Songtext
            PowerPraiseSong.Part part = new PowerPraiseSong.Part
            {
                Caption = "Teil 1"
            };

            PowerPraiseSong.Slide slide = new PowerPraiseSong.Slide
            {
                MainSize = 42,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir,");
            slide.Lines.Add("sei meine Bitt'!");
            slide.Lines.Add("Näher, o Herr, zu Dir");
            slide.Lines.Add("mit jedem Schritt.");
            part.Slides.Add(slide);

            slide = new PowerPraiseSong.Slide
            {
                MainSize = 44,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
            slide.Lines.Add("Nur an dem Herzen Dein");
            slide.Lines.Add("kann ich geborgen sein;");
            slide.Lines.Add("deshalb die Bitte mein:");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            ppl.Parts.Add(part);

            part = new PowerPraiseSong.Part
            {
                Caption = "Teil 2"
            };

            slide = new PowerPraiseSong.Slide
            {
                MainSize = 42,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Ein jeder Tag");
            slide.Lines.Add("soll es neu zeigen mir,");
            slide.Lines.Add("was er vermag:");
            part.Slides.Add(slide);

            slide = new PowerPraiseSong.Slide
            {
                MainSize = 42,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
            slide.Lines.Add("Wie seiner Gnade Macht,");
            slide.Lines.Add("Erlösung hat gebracht,");
            slide.Lines.Add("in uns're Sündennacht.");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            ppl.Parts.Add(part);

            part = new PowerPraiseSong.Part
            {
                Caption = "Teil 3"
            };

            slide = new PowerPraiseSong.Slide
            {
                MainSize = 42,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Dich bet' ich an.");
            slide.Lines.Add("Wie vieles hast an mir,");
            slide.Lines.Add("Du doch getan!");
            part.Slides.Add(slide);

            slide = new PowerPraiseSong.Slide
            {
                MainSize = 42,
                Background = new ImageBackground("Blumen\\Blume 3.jpg")
            };
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
            ppl.Formatting.CopyrightTextPosition = AdditionalInformationPosition.LastSlide;

            // Source
            ppl.SourceText = "grünes Buch 339";
            ppl.Formatting.SourceTextPosition = AdditionalInformationPosition.FirstSlide;

            // Formatting
            ppl.Formatting.MainText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Times New Roman", 44, FontStyle.Bold | FontStyle.Italic),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 15
            };
            ppl.Formatting.TranslationText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Times New Roman", 20, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.Formatting.CopyrightText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Times New Roman", 14, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.Formatting.SourceText = new PowerPraiseSongFormatting.FontFormatting
            {
                Font = new Font("Times New Roman", 30, FontStyle.Regular),
                Color = Color.White,
                OutlineWidth = 30,
                ShadowDistance = 20
            };
            ppl.Formatting.Outline = new PowerPraiseSongFormatting.OutlineFormatting
            {
                Color = Color.Black,
                Enabled = false
            };
            ppl.Formatting.Shadow = new PowerPraiseSongFormatting.ShadowFormatting
            {
                Color = Color.Black,
                Direction = 125,
                Enabled = true
            };

            // Line spacing
            ppl.Formatting.MainLineSpacing = 30;
            ppl.Formatting.TranslationLineSpacing = 20;

            // Text orientation
            ppl.Formatting.TextOrientation = new TextOrientation(VerticalOrientation.Middle, HorizontalOrientation.Left);
            ppl.Formatting.TranslationPosition = TranslationPosition.Inline;

            // Borders
            ppl.Formatting.Borders = new PowerPraiseSongFormatting.TextBorders
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
            SongAuthor a = new SongAuthor
            {
                Name = "asd as d"
            };
            song.Author.Add(a);
            song.Publisher = "Sparrow Records";
            song.RightsManagement = "Verlag ABC";

            return song;
        }
    }
}
