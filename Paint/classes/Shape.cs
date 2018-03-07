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
    abstract class Shape : ICloneable
    {
        public System.Windows.Shapes.Shape drawBase;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                SetFill();
            }
        }
        private Color color;

        public Point Vertex1
        {
            get
            {
                return vertex1;
            }
            set
            {
                vertex1 = value;
            }
        }
        protected Point vertex1;

        public Point Vertex2
        {
            get
            {
                return vertex2;
            }
            set
            {
                vertex2 = value;
                SetSides();
            }
        }
        protected Point vertex2;

        public virtual double Width
        {
            get
            {
                return drawBase.Width;
            }
            set
            {
                drawBase.Width = value;
            }
        }
        public virtual double Height
        {
            get
            {
                return drawBase.Height;
            }
            set
            {
                drawBase.Height = value;
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                SetAngle();
            }
        }
        private double angle;

        public Shape(Color color, Point vertex1, Point vertex2)
        {
            this.color = color;
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            angle = 0;

            drawBase = GenerateDrawBase();
            SetSides();
            SetFill();
        }

        public void Draw(Canvas canvas, List<Shape> history)
        {
            Canvas.SetLeft(drawBase, Vertex1.X);
            Canvas.SetTop(drawBase, Vertex1.Y);
            canvas.Children.Add(drawBase);
            history.Add(this);
        }

        public void Move(Canvas canvas, Point delta)
        {
            Point topLeft = new Point(Vertex1.X + delta.X, Vertex1.Y + delta.Y);

            Vertex1 = topLeft;
            Vertex2 = new Point(Vertex1.X + Width, Vertex1.Y + Height);

            Canvas.SetLeft(drawBase, topLeft.X);
            Canvas.SetTop(drawBase, topLeft.Y);
        }

        protected abstract System.Windows.Shapes.Shape GenerateDrawBase();

        protected abstract void SetSides();

        private void SetFill()
        {
            drawBase.Fill = new SolidColorBrush(color);
        }

        private void SetAngle()
        {
            drawBase.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
        }

        public object Clone()
        {
            drawBase = GenerateDrawBase();
            return MemberwiseClone();
        }

        // Не используется пока
        //private void CalcVertecies(Point v1, Point v2)
        //{
        //    if (v1.X > v2.X)
        //    {
        //        if (v1.Y > v2.Y)
        //        {
        //            topLeft = v2;
        //            bottomRight = v1;
        //        }
        //        else
        //        {
        //            topLeft.X = v2.X;
        //            bottomRight.X = v1.X;
        //        }
        //    }
        //    else
        //    {
        //        if (v1.Y > v2.Y)
        //        {
        //            topLeft.Y = v2.Y;
        //            bottomRight.Y = v1.Y;
        //        }
        //        else
        //        {
        //            topLeft = v1;
        //            bottomRight = v2;
        //        }
        //    }
        //}
    }
}
