using kyrsovuy.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy
{
    class Utils
    {
        public static bool polyphonyCrossCircle(Circle circle,
                                                Point startLine, Point endLine)
        {
            double dx, dy, A, B, C, det;

            dx = endLine.X - startLine.X;
            dy = endLine.Y - startLine.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (startLine.X - circle.Centre.X) + dy * (startLine.Y - circle.Centre.Y));
            C = (startLine.X - circle.Centre.X) * (startLine.X - circle.Centre.X) + (startLine.Y - circle.Centre.Y) * (startLine.Y - circle.Centre.Y) - circle.Radius * circle.Radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
