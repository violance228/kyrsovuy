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
        private Pen pen = new Pen(Color.Red, 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs eventArgs)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Point pointStart = new Point(50, 0);
            Point pointEnd = new Point(500, 300);
            graphics.DrawLine(pen, pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);

            foreach(Circle circle in circleService.Circles)
            {
                int size = (int)circle.Radius * 2;
                graphics.DrawEllipse(pen, new Rectangle(circle.Centre.X, circle.Centre.Y, size, size));
            }
        }
    }
}
