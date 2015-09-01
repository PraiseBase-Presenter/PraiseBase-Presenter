using System;

namespace PraiseBase.Presenter.Persistence
{
    /// <summary>
    ///     Thrown when the file lacks important contents
    /// </summary>
    public class InvalidSongSourceFileException : Exception
    {
        public InvalidSongSourceFileException()
        {
        }

        public InvalidSongSourceFileException(string message)
            : base(message)
        {
        }

        public InvalidSongSourceFileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}