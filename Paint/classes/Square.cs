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
    class Square : Rectangle // interfaces
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
                base.Height = value;
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
        
        public Square(Color color, Point topLeft, Point bottomRight) : base(color, topLeft, bottomRight)
        {
        }
    }
}
