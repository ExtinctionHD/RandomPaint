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

        private Creator curCreator;
        private Color curColor;
        private Shape curShape;
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
                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Square(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
                if (curShape.GetType() == typeof(Ellipse))
                {
                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Circle(curShape);
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
                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Rectangle(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
                if ((bool)ellipse.IsChecked)
                {
                    canvas.Children.Remove(curShape.drawBase);

                    curShape = new Ellipse(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
            }
        }
        
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Pen;

            curColor = GetRandomColor();
            Point curPos = e.GetPosition(canvas);
            curShape = curCreator.FactoryMethod(curColor, curPos, curPos);

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

        // Выбор фигуры
        private void rectangle_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new RectangleCreator();
        }
        private void ellipse_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new EllipseCreator();
        }
        private void triangleR_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new RightTriangleCreator();
        }
        private void triangleI_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new IsoscelesTriangleCreator();
        }
        private void pentagon_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new PentagonCreator();
        }
        private void star_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new StarCreator();
        }
        private void randomShape_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new RandomCreator();
        }
    }
}
