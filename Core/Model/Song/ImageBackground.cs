using System;
using System.Runtime.Serialization;

namespace PraiseBase.Presenter.Model.Song
{
    [Serializable]
    public class ImageBackground : IBackground
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="imagePath">Image path</param>
        public ImageBackground(string imagePath)
        {
            ImagePath = imagePath;
        }

        /// <summary>
        ///     The image path relative to the backgrounds directory
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        ///     Clone method
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new ImageBackground(ImagePath);
        }

        /// <summary>
        ///     Gets the object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ImagePath", ImagePath);
        }

        public override int GetHashCode()
        {
            return ImagePath.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType() && ImagePath.Equals(((ImageBackground) obj).ImagePath);
        }
    }
}