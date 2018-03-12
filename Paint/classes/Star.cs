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
    class Star : Polygon
    {
        public Star(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        protected override Point[] GeneratePolygon()
        {
            double width = Vertex2.X - Vertex1.X;
            double height = Vertex2.Y - Vertex1.Y;

            Point[] star = new Point[]
            {
                new Point(width / 2, 0),
                new Point(0.6 * width, 0.365 * height),
                new Point(width, 0.365 * height),
                new Point(0.6875 * width, 0.6 * height),
                new Point(0.8125 * width, height),
                new Point(width / 2, 0.757 * height),
                new Point(0.1875 * width, height),
                new Point(0.3125 * width, 0.6 * height),
                new Point(0, 0.365 * height),
                new Point(0.3875 * width, 0.365 * height),
            };
            return star;
        }
    }
}
