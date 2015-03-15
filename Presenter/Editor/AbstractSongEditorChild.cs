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
        protected int CurrentPartId;

        /// <summary>
        /// Index of currently selected slide
        /// </summary>
        protected int CurrentSlideId;

        /// <summary>
        /// Settings instance holder
        /// </summary>
        protected readonly Settings Settings;

        /// <summary>
        /// Song template mapper instance
        /// </summary>
        protected SongTemplateMapper TemplateMapper;

        /// <summary>
        /// Image manager instance
        /// </summary>
        protected readonly ImageManager ImgManager;

        /// <summary>
        /// Slide text formatting mapper
        /// </summary>
        protected readonly ISlideTextFormattingMapper<Song> PreviewFormattingMapper = new SongSlideTextFormattingMapper();

        #endregion

        public AbstractSongEditorChild() : this(null, null)
        {
        }

        public AbstractSongEditorChild(Settings settings, ImageManager imgManager)
        {
            Settings = settings;
            ImgManager = imgManager;
            TemplateMapper = new SongTemplateMapper(Settings);

            InitializeComponent();
        }

        protected Image PreviewSlide(Song sng, string currentText, string currentTranslationText)
        {
            SongSlide slide = (SongSlide)sng.Parts[CurrentPartId].Slides[CurrentSlideId].Clone();
            slide.Text = currentText;
            slide.TranslationText = currentTranslationText;
            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            PreviewFormattingMapper.Map(sng, ref slideFormatting);

            // Disabled for performance
            slideFormatting.OutlineEnabled = false;
            slideFormatting.SmoothShadow = false;

            slideFormatting.ScaleFontSize = Settings.ProjectionFontScaling;
            slideFormatting.SmoothShadow = false;

            TextLayer sl = new TextLayer(slideFormatting)
            {
                MainText = slide.Lines.ToArray(),
                SubText = slide.Translation.ToArray()
            };

            ImageLayer il = new ImageLayer(Settings.ProjectionBackColor);

            IBackground bg = sng.Parts[CurrentPartId].Slides[CurrentSlideId].Background;
            il.Image = ImgManager.GetImage(bg);

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
