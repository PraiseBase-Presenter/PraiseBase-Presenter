using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pbp
{
    class Projection
    {
	    /// <summary>
	    /// The singleton holder
	    /// </summary>
        static private Projection _instance;

	    /// <summary>
	    /// Private constructor
	    /// </summary>
        private Projection()
        {

        }

	    /// <summary>
	    /// Returns the singleton instance of this class
	    /// </summary>
	    /// <returns></returns>
        static public Projection Instance
        {
		    get
		    {
                if (_instance == null)
                    _instance = new Projection();
			    return _instance;
		    }
        }

        private Bitmap ForeGround;
        private Bitmap BackGround;

        public void setForeground()
        {

        }

        public void setBackground()
        {

        }

    }
}
