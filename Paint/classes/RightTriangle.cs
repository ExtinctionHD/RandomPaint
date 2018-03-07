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
    class RightTriangle : Triangle
    {
        public RightTriangle(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        protected override Point[] GenerateTriangle()
        {
            Point[] triangle = new Point[3]
            {
                new Point(0, 0),
                new Point(vertex2.X - vertex1.X, vertex2.Y - vertex1.Y),
                new Point(0, vertex2.Y - vertex1.Y)
            };
            return triangle;
        }
    }
}
