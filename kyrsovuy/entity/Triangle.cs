using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.entity
{
    public class Triangle : Figure
    {
        private Point topPoint;
        private Point leftPoint;
        private Point rightPoint;

        internal Point TopPoint { get => topPoint; set => topPoint = value; }
        internal Point LeftPoint { get => leftPoint; set => leftPoint = value; }
        internal Point RightPoint { get => rightPoint; set => rightPoint = value; }

        public Color getColor()
        {
            return Color.SpringGreen;
        }

        public bool IsCrossesPolyphony()
        {
            throw new NotImplementedException();
        }

        public double perimeter()
        {
            throw new NotImplementedException();
        }

        public double square()
        {
            throw new NotImplementedException();
        }
    }
}
