using kyrsovuy.entity;
using kyrsovuy.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = kyrsovuy.entity.Point;

namespace kyrsovuy
{
    public partial class Form1 : Form
    {
        CircleService circleService = CircleService.getInstance();
        PolyphonyService polyphonyService = PolyphonyService.getInstance(); 

        private Pen red = new Pen(Color.Red, 2);
        private Pen black = new Pen(Color.Black, 2);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs eventArgs)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();

            Point[] linePoints = new Point[polyphonyService.Polyphonies.Polyphonys.Count*2];
            int index = 0;
            foreach (Line line in polyphonyService.Polyphonies.Polyphonys)
            {
                linePoints[index++] = line.Start;
                linePoints[index++] = line.End;
            }
            for(index = 0; index < linePoints.Length;)
            {
                float startX = linePoints[index].X;
                float startY = linePoints[index].Y;
                index = index + 1;
                float endX = startX;
                float endY = startY;
                if (index < linePoints.Length)
                {
                    endX = linePoints[index].X;
                    endY = linePoints[index].Y;
                }
                graphics.DrawLine(black, startX, startY, endX, endY);
            }

            List<Circle> maxAndMinCircle = new List<Circle>();

            int max = 0;
            int min = 0;
            foreach(Circle circle in circleService.Circles)
            {
                int size = circle.Radius * 2;
                graphics.DrawEllipse(black, circle.Centre.X - circle.Radius, circle.Centre.Y - circle.Radius, size, size);

                    foreach (Line line in polyphonyService.Polyphonies.Polyphonys)
                    {
                        if (Utils.isCrossCircle(circle, line))
                        {
                            circle.CrossesPolyphony = true;
                            if(circle.Radius > max)
                            {
                                max = circle.Radius;
                            } else if(min == 0 || min > circle.Radius)
                            {
                                min = circle.Radius;
                            }
                        }
                    }
            }

            foreach(Circle circle in circleService.Circles)
            {
                if(max != 0 && max == circle.Radius)
                {
                    maxAndMinCircle.Add(circle);
                    max = 0;
                }
                if (min != 0 && min == circle.Radius)
                {
                    maxAndMinCircle.Add(circle);
                    min = 0;
                }
            }

            foreach(Circle circle in maxAndMinCircle)
            {
                int size = circle.Radius * 2;
                graphics.DrawEllipse(red, circle.Centre.X - circle.Radius, circle.Centre.Y - circle.Radius, size, size);
            }
        }
    }
}
