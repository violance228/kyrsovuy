using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.entity
{
    class Polyphony
    {
        private List<Point> points;

        public Polyphony()
        {
            this.points = new List<Point>();
        }

        public List<Point> Points { get => points; }

        public void setPoint(Point point)
        {
            points.Add(point);
        }
    }
}
