using kyrsovuy.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovuy.service
{
    public class CircleService
    {
        private const String circlePath = "E:\\univercity\\черняк 4курс\\kyrsovuy\\kyrsovuy\\initCircle.txt";

        private static CircleService singleton = null;
        private List<Circle> circles;

        private CircleService() {}

        public List<Circle> Circles { get => circles; set => circles = value; }

        public static CircleService getInstance()
        {
            if (singleton == null)
            {
                singleton = new CircleService();
                singleton.Circles = Utils.parseCircle(circlePath);
            }
            return singleton;
        }

        
    }
}
