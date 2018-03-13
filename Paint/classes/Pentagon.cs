using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint.classes
{
    class Pentagon : Polygon
    {
        public Pentagon(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        public Pentagon(Shape shape): base(shape)
        {
        }

        protected override Point[] GeneratePolygon()
        {
            Point[] pentagon = new Point[]
            {
                new Point(Width / 2, 0),
                new Point(Width, 0.365 * Height),
                new Point(0.8125 * Width, Height),
                new Point(0.1875 * Width, Height),
                new Point(0, 0.365 * Height),
            };
            return pentagon;
        }
    }
}
