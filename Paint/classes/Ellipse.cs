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
    class Ellipse : Rectangle
    {
        public Ellipse(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }

        protected override void SetSides()
        {
            base.SetSides();
            ((System.Windows.Shapes.Rectangle)drawBase).RadiusX = drawBase.Width / 2;
            ((System.Windows.Shapes.Rectangle)drawBase).RadiusY = drawBase.Height / 2;
        }
    }
}
