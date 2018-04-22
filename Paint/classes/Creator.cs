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
using System.Reflection;

namespace Paint.classes
{
    abstract class Creator
    {
        public abstract Shape FactoryMethod(Color color, Point v1, Point v2);
    }

    class RectangleCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Rectangle(color, v1, v2);
        }
    }

    class SquareCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Square(color, v1, v2);
        }
    }

    class EllipseCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Ellipse(color, v1, v2);
        }
    }

    class CircleCreator : Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Circle(color, v1, v2);
        }
    }

    class IsoscelesTriangleCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new IsoscelesTriangle(color, v1, v2);
        }
    }

    class RightTriangleCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new RightTriangle(color, v1, v2);
        }
    }

    class PentagonCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Pentagon(color, v1, v2);
        }
    }

    class HexagonCreator : Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Hexagon(color, v1, v2);
        }
    }

    class StarCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            return new Star(color, v1, v2);
        }
    }

    class RandomCreator: Creator
    {
        public override Shape FactoryMethod(Color color, Point v1, Point v2)
        {
            Type shape = typeof(Shape);
            List<Type> shapeTypes = Assembly.GetAssembly(shape).GetTypes().Where(type => type.IsSubclassOf(shape) && !type.IsAbstract).ToList();
            int i = new Random().Next(shapeTypes.Count);

            return (Shape)Activator.CreateInstance(shapeTypes[i], new Object[] { color, v1, v2 });
        }
    }
}
