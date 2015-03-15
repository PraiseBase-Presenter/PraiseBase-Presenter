using System.Drawing;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    static class PowerPraiseTestUtil
    {
        public static Song GetExpectedSong()
        {
            Song song = new Song
            {
                Title = "Näher, mein Gott, zu Dir",
                Language = "Deutsch"
            };

            song.Themes.Add("Anbetung");

            song.Copyright = "Text und Musik: Lowell Mason, 1792-1872";
            song.CopyrightPosition = AdditionalInformationPosition.LastSlide;

            SongBook sb = new SongBook
            {
                Name = "grünes Buch 339"
            };
            song.SongBooks.Add(sb);
            song.SourcePosition = AdditionalInformationPosition.FirstSlide;

            SongPart part = new SongPart
            {
                Caption = "Teil 1"
            };

            SongSlide slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 42
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir,");
            slide.Lines.Add("sei meine Bitt'!");
            slide.Lines.Add("Näher, o Herr, zu Dir");
            slide.Lines.Add("mit jedem Schritt.");
            part.Slides.Add(slide);

            slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 44
            };
            slide.Lines.Add("Nur an dem Herzen Dein");
            slide.Lines.Add("kann ich geborgen sein;");
            slide.Lines.Add("deshalb die Bitte mein:");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            song.Parts.Add(part);

            part = new SongPart
            {
                Caption = "Teil 2"
            };

            slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 42
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Ein jeder Tag");
            slide.Lines.Add("soll es neu zeigen mir,");
            slide.Lines.Add("was er vermag:");
            part.Slides.Add(slide);

            slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 42
            };
            slide.Lines.Add("Wie seiner Gnade Macht,");
            slide.Lines.Add("Erlösung hat gebracht,");
            slide.Lines.Add("in uns're Sündennacht.");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            song.Parts.Add(part);

            part = new SongPart
            {
                Caption = "Teil 3"
            };

            slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 42
            };
            slide.Lines.Add("Näher, mein Gott, zu Dir!");
            slide.Lines.Add("Dich bet' ich an.");
            slide.Lines.Add("Wie vieles hast an mir,");
            slide.Lines.Add("Du doch getan!");
            part.Slides.Add(slide);

            slide = new SongSlide
            {
                Background = new ImageBackground("Blumen\\Blume 3.jpg"),
                TextSize = 42
            };
            slide.Lines.Add("Von Banden frei und los,");
            slide.Lines.Add("ruh' ich in Deinem Schoss.");
            slide.Lines.Add("Ja, Deine Gnad' ist gross!");
            slide.Lines.Add("Näher zu Dir!");
            part.Slides.Add(slide);
            song.Parts.Add(part);

            song.PartSequence.Add(song.Parts[0]);
            song.PartSequence.Add(song.Parts[1]);
            song.PartSequence.Add(song.Parts[2]);

            song.MainText = new TextFormatting(
                new Font("Times New Roman", 44, FontStyle.Bold | FontStyle.Italic),
                Color.White,
                new TextOutline(30, Color.Black),
                new TextShadow(15, 0, 125, Color.Black),
                30
            );
            song.TranslationText = new TextFormatting(
                new Font("Times New Roman", 20, FontStyle.Regular),
                Color.White,
                new TextOutline(30, Color.Black),
                new TextShadow(20, 0, 125, Color.Black),
                20
            );
            song.CopyrightText = new TextFormatting(
                new Font("Times New Roman", 14, FontStyle.Regular),
                Color.White,
                new TextOutline(30, Color.Black),
                new TextShadow(20, 0, 125, Color.Black),
                0
            );
            song.SourceText = new TextFormatting(
                new Font("Times New Roman", 30, FontStyle.Regular),
                Color.White,
                new TextOutline(30, Color.Black),
                new TextShadow(20, 0, 125, Color.Black),
                0
            );

            song.TextOrientation = new TextOrientation(VerticalOrientation.Middle, HorizontalOrientation.Left);

            song.TextOutlineEnabled = false;
            song.TextShadowEnabled = true;

            song.TextBorders = new SongTextBorders(50, 40, 60, 70, 30, 20, 40);

            return song;
        }

        public static PowerPraiseSong GetExpectedPowerPraiseSong()
        {

            PowerPraiseSong ppl = new PowerPraiseSong
            {
                Title = "Näher, mein Gott, zu Dir",
                Language = "Deutsch",
                Category = "Anbetung"
            };

            // General

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
            ppl.CopyrightTextPosition = PowerPraiseSong.CopyrightPosition.LastSlide;

            // Source
            ppl.SourceText = "grünes Buch 339";
            ppl.SourceTextEnabled = true;

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

    }
}
