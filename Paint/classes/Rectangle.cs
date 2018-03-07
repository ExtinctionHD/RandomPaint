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

        protected override System.Windows.Shapes.Shape GenerateDrawBase()
        {
            return new System.Windows.Shapes.Rectangle();
        }

        protected override void SetSides()
        {
            if (vertex2.X - vertex1.X >= 0)
                Width = vertex2.X - vertex1.X;

            if (vertex2.Y - vertex1.Y >= 0)
                Height = vertex2.Y - vertex1.Y;
        }
    }
}
