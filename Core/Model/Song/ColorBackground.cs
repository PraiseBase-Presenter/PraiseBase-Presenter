using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PraiseBase.Presenter.Model.Song
{
    [Serializable()]
    public class ColorBackground : IBackground
    {
        /// <summary>
        /// The color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Color</param>
        public ColorBackground(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Clone method
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new ColorBackground(Color);
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType() && Color.Equals(((ColorBackground)obj).Color);
        }

        /// <summary>
        /// Gets the object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Color", this.Color);
        }
    }
}
