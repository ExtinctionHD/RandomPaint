﻿using System;
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
    abstract class Shape
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

        // Левая верхняя вершина
        public Point Vertex1
        {
            get
            {
                return vertex1;
            }
            set
            {
                vertex1 = value;
                SetPosition();
            }
        }
        private Point vertex1;

        // Правая нижняя вершина
        public virtual Point Vertex2
        {
            get
            {
                return vertex2;
            }
            set
            {
                SetVertex2X(value);
                SetVertex2Y(value);

                SetPosition();
                SetSides();
            }
        }
        private Point vertex2;

        public bool reverseX, reverseY;

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
            drawBase = GenerateDrawBase();

            this.color = color;
            this.vertex1 = vertex1;

            SetVertex2X(vertex2);
            SetVertex2Y(vertex2);

            SetPosition();
            SetSides();
            SetFill();

            angle = 0;
        }

        public void Draw(Canvas canvas, List<Shape> history)
        {
            canvas.Children.Add(drawBase);
            history.Add(this);
        }

        public void Move(Point delta)
        {
            Vertex1 = new Point(Vertex1.X + delta.X, Vertex1.Y + delta.Y);
            Vertex2 = new Point(Vertex1.X + Width, Vertex1.Y + Height);
        }

        public void Remove(Canvas canvas, List<Shape> history)
        {
            canvas.Children.Remove(drawBase);
            history.Remove(this);
        }

        protected abstract System.Windows.Shapes.Shape GenerateDrawBase();

        private void SaveSides(Point v1)
        {
            vertex1 = v1;
            vertex2 = new Point(vertex1.X + Width, vertex1.Y + Height);
        }

        protected void SetVertex2X(Point v2)
        {
            double v1X = Vertex1.X;
            if (reverseX)
            {
                v1X += Width;
            }

            if (v1X > v2.X)
            {
                vertex1.X = v2.X;

                vertex2.X = v1X;
                reverseX = true;
            }
            else
            {
                vertex2.X = v2.X;
                reverseX = false;
            }
        }

        protected void SetVertex2Y(Point v2)
        {
            double v1Y = Vertex1.Y;
            if (reverseY)
            {
                v1Y += Height;
            }

            if (v1Y > v2.Y)
            {
                vertex1.Y = v2.Y;

                vertex2.Y = v1Y;
                reverseY = true;
            }
            else
            {
                vertex2.Y = v2.Y;
                reverseY = false;
            }
        }

        private void SetPosition()
        {
            Canvas.SetLeft(drawBase, Vertex1.X);
            Canvas.SetTop(drawBase, Vertex1.Y);
        }

        protected abstract void SetSides();

        private void SetFill()
        {
            drawBase.Fill = new SolidColorBrush(color);
        }

        private void SetAngle()
        {
            drawBase.RenderTransform = new RotateTransform(angle, Width / 2, Height / 2);
        }

    }
}
