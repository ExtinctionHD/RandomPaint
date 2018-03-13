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
    class Circle : Ellipse, IEquilateral
    {
        public override Point Vertex2
        {
            get
            {
                return base.Vertex2;
            }
            set
            {
                base.Vertex2 = SetEqualSides(value);
            }
        }

        public Circle(Color color, Point vertex1, Point vertex2): base(color, vertex1, vertex2)
        {
        }

        public Circle(Shape shape): base(shape)
        {
        }

        public Point SetEqualSides(Point v2)
        {
            double height, width;

            if (!reverseX)
            {
                width = v2.X - Vertex1.X;

                if (width <= 0)
                {
                    return v2;
                }

                if (!reverseY)
                {
                    height = v2.Y - Vertex1.Y;

                    if (height <= 0)
                    {
                        return v2;
                    }

                    if (height < width)
                    {
                        v2.X = Vertex1.X + height;
                    }
                    else
                    {
                        v2.Y = Vertex1.Y + width;
                    }
                }
                else
                {
                    height = Vertex2.Y - v2.Y;

                    if (height <= 0)
                    {
                        return v2;
                    }

                    if (height < width)
                    {
                        v2.X = Vertex1.X + height;
                    }
                    else
                    {
                        v2.Y = Vertex2.Y - width;
                    }
                }
            }
            else
            {
                width = Vertex2.X - v2.X;

                if (width <= 0)
                {
                    return v2;
                }

                if (!reverseY)
                {
                    height = v2.Y - Vertex1.Y;

                    if (height <= 0)
                    {
                        return v2;
                    }

                    if (height < width)
                    {
                        v2.X = Vertex2.X - height;
                    }
                    else
                    {
                        v2.Y = Vertex1.Y + width;
                    }
                }
                else
                {
                    height = Vertex2.Y - v2.Y;

                    if (height <= 0)
                    {
                        return v2;
                    }

                    if (height < width)
                    {
                        v2.X = Vertex2.X - height;
                    }
                    else
                    {
                        v2.Y = Vertex2.Y - width;
                    }
                }
            }

            return v2;
        }
    }
}
