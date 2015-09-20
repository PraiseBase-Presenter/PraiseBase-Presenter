using System;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFilePlugin : AbstractSongFilePlugin<SongSelectFile>
    {
        public SongSelectFilePlugin()
        {
            Reader = new SongSelectFileReader();
            Mapper = new SongSelectFileMapper();
        }

        public override string GetFileExtension()
        {
            return ".usr";
        }

        public override string GetFileTypeDescription()
        {
            return "SongSelect Import File";
        }

        public override bool IsImportSupported()
        {
            return true;
        }

        public override int LoadingOrder()
        {
            return 2;
        }
    }
}