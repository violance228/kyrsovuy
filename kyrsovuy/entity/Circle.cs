using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.entity
{
    public class Circle : Figure
    {
        private const double PI = 3.14d;
        private double radius;
        private Point centre;
        private bool isCrossesPolyphony;

        public Circle(double radius, Point centre)
        {
            this.radius = radius;
            this.centre = centre;
            this.isCrossesPolyphony = false;
        }

        public bool IsCrossesPolyphony()
        {
            return isCrossesPolyphony;
        }

        public double perimeter()
        {
            return 2 * PI * Radius;
        }

        public double square()
        {
            return PI * (Radius * Radius);
        }

        public double Radius { get => radius; set => radius = value; }
        internal Point Centre { get => centre; set => centre = value; }


        public override bool Equals(object obj)
        {
            var circle = obj as Circle;
            return circle != null &&
                   Radius == circle.Radius &&
                   EqualityComparer<Point>.Default.Equals(Centre, circle.Centre) &&
                   isCrossesPolyphony == circle.isCrossesPolyphony;
        }

        public override int GetHashCode()
        {
            var hashCode = 1160767416;
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Point>.Default.GetHashCode(Centre);
            hashCode = hashCode * -1521134295 + isCrossesPolyphony.GetHashCode();
            return hashCode;
        }

        public Color getColor()
        {
            return Color.Red;
        }
    }
}
