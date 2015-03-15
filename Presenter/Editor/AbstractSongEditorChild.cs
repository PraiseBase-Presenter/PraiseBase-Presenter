using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;

namespace PraiseBase.Presenter.Editor
{
    public partial class AbstractSongEditorChild : Form
    {
        #region Internal variables
        
        /// <summary>
        /// Index of currently selected part
        /// </summary>
        protected int _currentPartId;

        /// <summary>
        /// Index of currently selected slide
        /// </summary>
        protected int _currentSlideId;

        /// <summary>
        /// Settings instance holder
        /// </summary>
        protected readonly Settings _settings;

        /// <summary>
        /// Song template mapper instance
        /// </summary>
        protected SongTemplateMapper _templateMapper;

        /// <summary>
        /// Image manager instance
        /// </summary>
        protected readonly ImageManager _imgManager;

        /// <summary>
        /// Slide text formatting mapper
        /// </summary>
        protected readonly ISlideTextFormattingMapper<Song> _previewFormattingMapper = new SongSlideTextFormattingMapper();

        #endregion

        public AbstractSongEditorChild() : this(null, null)
        {
        }

        public AbstractSongEditorChild(Settings settings, ImageManager imgManager)
        {
            _settings = settings;
            _imgManager = imgManager;
            _templateMapper = new SongTemplateMapper(_settings);

            InitializeComponent();
        }

        protected Image PreviewSlide(Song sng, string currentText, string currentTranslationText)
        {
            SongSlide slide = (SongSlide)sng.Parts[_currentPartId].Slides[_currentSlideId].Clone();
            slide.Text = currentText;
            slide.TranslationText = currentTranslationText;
            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            _previewFormattingMapper.Map(sng, ref slideFormatting);

            // Disabled for performance
            slideFormatting.OutlineEnabled = false;
            slideFormatting.SmoothShadow = false;

            slideFormatting.ScaleFontSize = _settings.ProjectionFontScaling;
            slideFormatting.SmoothShadow = false;

            TextLayer sl = new TextLayer(slideFormatting)
            {
                MainText = slide.Lines.ToArray(),
                SubText = slide.Translation.ToArray()
            };

            ImageLayer il = new ImageLayer(_settings.ProjectionBackColor);

            IBackground bg = sng.Parts[_currentPartId].Slides[_currentSlideId].Background;
            il.Image = _imgManager.GetImage(bg);

            var bmp = new Bitmap(1024, 768);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.HighSpeed;
            gr.SmoothingMode = SmoothingMode.HighSpeed;

            il.WriteOut(gr, null);
            sl.WriteOut(gr, null);

            return bmp;
        }
    }
}
