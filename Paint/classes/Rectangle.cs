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
    class Rectangle : Shape
    {       
        public Rectangle(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        public Rectangle(Shape shape) : base(shape.Color, shape.Vertex1, shape.Vertex2)
        {
            reverseX = shape.reverseX;
            reverseY = shape.reverseY;
        }

        protected override System.Windows.Shapes.Shape GenerateDrawBase()
        {
            return new System.Windows.Shapes.Rectangle();
        }

        protected override void SetSides()
        {
            Width = Vertex2.X - Vertex1.X;
            Height = Vertex2.Y - Vertex1.Y;
        }
    }
}
