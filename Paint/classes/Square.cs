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
    class Square : Rectangle, IEquilateral
    {
        public override double Width
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
        public override double Height
        {
            get
            {
                return drawBase.Height;
            }
            set
            {
                drawBase.Height = value;
                SetEqualSides(value);
            }
        }

        public void SetEqualSides(double height)
        {
            if (height <= Width)
            {
                base.Width = height;
            }
            else
            {
                base.Height = Width;
            }
        }
        
        public Square(Color color, Point topLeft, Point bottomRight) : base(color, topLeft, bottomRight)
        {
        }
    }
}
