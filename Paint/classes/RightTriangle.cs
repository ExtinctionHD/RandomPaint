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
    class RightTriangle : Polygon
    {
        public RightTriangle(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        protected override Point[] GeneratePolygon()
        {
            Point[] triangle = new Point[3]
            {
                new Point(0, 0),
                new Point(Vertex2.X - Vertex1.X, Vertex2.Y - Vertex1.Y),
                new Point(0, Vertex2.Y - Vertex1.Y)
            };
            return triangle;
        }
    }
}
