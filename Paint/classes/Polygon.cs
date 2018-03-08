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
    abstract class Polygon : Shape
    {
        public override double Width
        {
            get
            {
                return drawBase.ActualWidth;
            }
        }
        public override double Height
        {
            get
            {
                return drawBase.ActualHeight;
            }
        }

        public Polygon(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        protected override System.Windows.Shapes.Shape GenerateDrawBase()
        {
            return new System.Windows.Shapes.Polygon();
        }

        protected override void SetSides()
        {
            if (vertex2.X - vertex1.X >= 0 && vertex2.Y - vertex1.Y >= 0)
            {
                ((System.Windows.Shapes.Polygon)drawBase).Points = new PointCollection(GeneratePolygon());
            }
        }

        protected abstract Point[] GeneratePolygon();
    }
}
