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

        protected override Point[] GeneratePolygon()
        {
            double width = vertex2.X - vertex1.X;
            double height = vertex2.Y - vertex1.Y;

            Point[] pentagon = new Point[]
            {
                new Point(width / 2, 0),
                new Point(width, 0.365 * height),
                new Point(0.8125 * width, height),
                new Point(0.1875 * width, height),
                new Point(0, 0.365 * height),
            };
            return pentagon;
        }
    }
}
