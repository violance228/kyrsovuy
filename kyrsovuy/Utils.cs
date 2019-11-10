using kyrsovuy.entity;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static List<Circle> parseCircle(String path)
        {
            List<Circle> figures = new List<Circle>();

            StreamReader reader = File.OpenText(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.ToLower().Trim().Split(' ');
                String x = null;
                String y = null;
                String radius = null;
                for (int i = 0; i < items.Length; i++)
                {
                    if(items[i].Equals("x"))
                    {
                        x = items[i + 2];
                    } else if(items[i].Equals("y"))
                    {
                        y = items[i + 2];
                    } else if(items[i].Equals("radius"))
                    {
                        radius = items[i + 2];
                    }
                }
                if(x != null && y != null && radius != null)
                { 
                    figures.Add(new Circle(double.Parse(radius), new Point(int.Parse(x), int.Parse(y))));
                }
            }

            return figures;
        }

        public static Polyphony parseLine(String path)
        {
            Polyphony polyphony = new Polyphony();

            return polyphony;
        }
    }
}
