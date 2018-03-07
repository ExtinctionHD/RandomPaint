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
using Paint.classes;

namespace Paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private Point RightButtonDownPos;

        private Color curColor;
        private Shape curShape;
        private List<Shape> allShapes = new List<Shape>()
        {
            new Rectangle(Colors.Black, new Point(), new Point()),
            new Ellipse(Colors.Black, new Point(), new Point()),
            new RightTriangle(Colors.Black, new Point(), new Point()),
            new IsoscelesTriangle(Colors.Black, new Point(), new Point())
        };
        private List<Shape> shapesHistory = new List<Shape>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Background = new SolidColorBrush(GetRandomColor());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Рисование равносторонних фигур
            if (e.Key == Key.LeftShift && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (curShape.GetType() == typeof(Rectangle))
                {
                    Shape tmp = curShape;

                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Square(curColor, tmp.Vertex1, tmp.Vertex2);
                    curShape.Draw(canvas, shapesHistory);
                }
                if (curShape.GetType() == typeof(Ellipse))
                {
                    Shape tmp = curShape;

                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Circle(curColor, tmp.Vertex1, tmp.Vertex2);
                    curShape.Draw(canvas, shapesHistory);
                }
            }

            // Удаление последней фигуры
            if (e.Key == Key.Z && Keyboard.IsKeyDown(Key.LeftCtrl) && canvas.Children.Count != 0)
            {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
                shapesHistory.Remove(shapesHistory.Last());
                if (shapesHistory.Count != 0)
                    curShape = shapesHistory.Last();
                else
                    curShape = null;
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // Рисование разносторонних фигур
            if (e.Key == Key.LeftShift && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if ((bool)rectangle.IsChecked)
                {
                    Shape tmp = curShape;

                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Rectangle(curColor, tmp.Vertex1, Mouse.GetPosition(canvas));
                    curShape.Draw(canvas, shapesHistory);
                }
                if ((bool)ellipse.IsChecked)
                {
                    Shape tmp = curShape;

                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Ellipse(curColor, tmp.Vertex1, Mouse.GetPosition(canvas));
                    curShape.Draw(canvas, shapesHistory);
                }
            }
        }
        
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Pen;

            curColor = GetRandomColor();
            curShape = ChoiceShape();

            Point startPoint = e.GetPosition(canvas);
            curShape.Vertex1 = startPoint;
            curShape.Vertex2 = startPoint;
            curShape.Color = curColor;

            curShape.Draw(canvas, shapesHistory);
        }

        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.SizeAll;

            RightButtonDownPos = e.GetPosition(canvas);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                curShape.Vertex2 = e.GetPosition(canvas);
            }

            if (e.RightButton == MouseButtonState.Pressed && curShape != null)
            {
                Point delta = new Point(e.GetPosition(canvas).X - RightButtonDownPos.X, e.GetPosition(canvas).Y - RightButtonDownPos.Y);
                curShape.Move(canvas, delta);
                RightButtonDownPos = e.GetPosition(canvas);
            }
        }

        private void canvas_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double ROTATE_SPEED = e.Delta / 20;
            curShape.Angle += ROTATE_SPEED;
        }

        private Color GetRandomColor()
        {
            byte[] rgb = new byte[3];
            random.NextBytes(rgb);
            return Color.FromRgb(rgb[0], rgb[1], rgb[2]);
        }

        private Shape ChoiceShape()
        {
            int index = 0;
            foreach (RadioButton btn in grShapeButtons.Children)
            {
                if ((bool)btn.IsChecked)
                {
                    index = grShapeButtons.Children.IndexOf(btn);
                    if (index == grShapeButtons.Children.Count - 1)
                    {
                        index = random.Next(allShapes.Count);
                    }
                }
            }

            return (Shape)allShapes[index].Clone();
        }
    }
}
