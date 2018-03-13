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
    class Hexagon : Polygon
    {
        public Hexagon(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        public Hexagon(Shape shape) : base(shape)
        {
        }

        protected override Point[] GeneratePolygon()
        {
            Point[] hexagon = new Point[]
            {
                new Point(0.5 * Width, 0),
                new Point(Width, 0.25 * Height),
                new Point(Width, 0.75 * Height),
                new Point(0.5 * Width, Height),
                new Point(0, 0.75 * Height),
                new Point(0, 0.25 * Height),
            };
            return hexagon;
        }
    }
}
