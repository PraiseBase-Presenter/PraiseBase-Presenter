namespace PraiseBase.Presenter.Editor
{
    public class EditorChildMetaData
    {
        public string Filename { get; set; }
        public int HashCode { get; set; }

        public EditorChildMetaData(string filename, int hashCode)
        {
            Filename = filename;
            HashCode = hashCode;
        }
    }
}
