using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.entity
{
    public class Polyphony
    {
        private List<Line> polyphony;

        public Polyphony()
        {
            this.polyphony = new List<Line>();
        }

        public List<Line> Polyphonys { get => polyphony; }

        public void setPoint(Line line)
        {
            polyphony.Add(line);
        }
    }
}
