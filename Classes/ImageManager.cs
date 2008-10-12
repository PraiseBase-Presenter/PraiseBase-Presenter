using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pbp.Properties;
using System.IO;
using System.Drawing;

namespace Pbp
{
    class ImageManager
    {
        static private ImageManager instance;
        private Image _currentImage;

        public Image currentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
            }
        }

        private ImageManager()
        {

        }

        static public ImageManager getInstance()
        {
            if (instance == null)
            {
                instance = new ImageManager();
            }
            return instance;
        }




    }
}
