using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp
{
    public abstract class TextLayer : BaseLayer
    {
        public void writeOut(System.Drawing.Graphics gr)
        {
            Object [] args = {};
            writeOut(gr, args, ProjectionMode.Projection);
        }
        public void writeOut(System.Drawing.Graphics gr, Object[] args)
        {
            writeOut(gr, args, ProjectionMode.Projection);
        }
        public abstract void writeOut(System.Drawing.Graphics gr, Object[] args, ProjectionMode pm);
    }
}
