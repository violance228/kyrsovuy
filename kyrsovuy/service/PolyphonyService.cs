using kyrsovuy.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.service
{
    public class PolyphonyService
    {
        private const String linePath = "E:\\univercity\\черняк 4курс\\kyrsovuy\\kyrsovuy\\initLine.txt";

        private static PolyphonyService singleton = null;
        private Polyphony polyphonies;

        private PolyphonyService() { }

        public Polyphony Polyphonies { get => polyphonies; set => polyphonies = value; }

        public static PolyphonyService getInstance()
        {
            if (singleton == null)
            {
                singleton = new PolyphonyService();
                singleton.Polyphonies = Utils.parseLine(linePath);
            }
            return singleton;
        }
    }
}
