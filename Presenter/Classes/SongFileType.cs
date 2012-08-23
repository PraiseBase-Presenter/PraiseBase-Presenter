namespace Pbp
{
    public class SongFileType
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public SongFileType(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }
    }
}