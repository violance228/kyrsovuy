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
        public static bool polyphonyCrossCircle(Circle circle, Line line)
        {
            line.Start = new Point(line.Start.X - circle.Centre.X, line.Start.Y - circle.Centre.Y);
            line.End = new Point(line.End.X - circle.Centre.X, line.End.Y - circle.Centre.Y);

            int dx = line.End.X - line.Start.X;
            int dy = line.End.Y - line.Start.Y;

            double a = dx * dx + dy * dy;
            double b = 2 * (line.Start.X * dx + line.Start.Y * dy);
            double c = Math.Pow(line.Start.X, 2) + Math.Pow(line.Start.Y, 2) - Math.Pow(circle.Radius, 2);

            if (-b < 0)
                return c < 0;

            if (-b < (2 * a))
                return ((4 * a * c - b * b) < 0);

            return (a + b + c) < 0;
        }

        public static bool isCrossCircle(Circle circle, Line line)
        {
            double AB = getLengthByPoints(line.Start, circle.Centre);
            double BC = getLengthByPoints(circle.Centre, line.End);
            double AC = getLengthByPoints(line.Start, line.End);

            double P = (AB + BC + AC) / 2;

            double H_ac = (2 * Math.Sqrt(
                (P * (P - BC) * (P - AC) * (P - AB)) / 2
                )) / AC;

            return H_ac < circle.Radius;
        }

        public static double getLengthByPoints(Point A, Point B)
        {
            return Math.Sqrt(
                (Math.Pow((B.X - A.X), 2) + (Math.Pow((B.Y - A.Y), 2)))
                );
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
                    figures.Add(new Circle(int.Parse(radius), new Point(int.Parse(x), int.Parse(y))));
                }
            }

            return figures;
        }

        public static Polyphony parseLine(String path)
        {
            Polyphony polyphony = new Polyphony();

            StreamReader reader = File.OpenText(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.ToLower().Trim().Split(' ');
                String startX = null;
                String startY = null;
                String endX = null;
                String endY = null;
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Equals("startx"))
                    {
                        startX = items[i + 2];
                    }
                    else if (items[i].Equals("starty"))
                    {
                        startY = items[i + 2];
                    }
                    if (items[i].Equals("endx"))
                    {
                        endX = items[i + 2];
                    }
                    else if (items[i].Equals("endy"))
                    {
                        endY = items[i + 2];
                    }
                }
                if ((startX != null && startY != null) || (endX != null && endY != null))
                {
                    polyphony.Polyphonys.Add(new Line(new Point(int.Parse(startX), int.Parse(startY)), new Point(int.Parse(endX), int.Parse(endY))));
                }
            }


            return polyphony;
        }
    }
}
