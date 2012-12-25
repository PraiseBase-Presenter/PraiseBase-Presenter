using System;

namespace Pbp
{
    public abstract class BaseLayer
    {
        public void writeOut(System.Drawing.Graphics gr)
        {
            Object[] args = { };
            writeOut(gr, args, ProjectionMode.Projection);
        }

        public void writeOut(System.Drawing.Graphics gr, Object[] args)
        {
            writeOut(gr, args, ProjectionMode.Projection);
        }

        public abstract void writeOut(System.Drawing.Graphics gr, Object[] args, ProjectionMode pm);
    }

    public enum ProjectionMode
    {
        Simulate,
        Projection
    }
}