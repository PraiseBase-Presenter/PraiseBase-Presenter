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

        public InvalidSongSourceFileException(String message) 
            : base(message)
        {
        }

        public InvalidSongSourceFileException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}