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
    class Circle : Ellipse
    {
        public override double Width
        {
            get
            {
                return drawBase.Width;
            }
            set
            {
                base.Width = value;
                if (value <= Height)
                {
                    base.Width = value;
                    base.Height = value;
                }
                else
                {
                    base.Height = Width;
                }
            }
        }
        public override double Height
        {
            get
            {
                return drawBase.Height;
            }
            set
            {
                drawBase.Height = value;
                if (value <= Width)
                {
                    base.Height = value;
                    base.Width = value;
                }
                else
                {
                    base.Height = Width;
                }
            }
        }
        
        public Circle(Color color, Point vertex1, Point vertex2) : base(color, vertex1, vertex2)
        {
        }
    }
}
