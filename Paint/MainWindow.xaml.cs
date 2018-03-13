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
using System.IO;
using Microsoft.Win32;
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
            Background = new SolidColorBrush(GetRandomColor());
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //SaveDilog();
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Рисование равносторонних фигур
            if (e.Key == Key.LeftShift && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if ((bool)rectangle.IsChecked)
                {
                    curShape.Remove(canvas, shapesHistory);

                    curShape = new Square(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
                if ((bool)ellipse.IsChecked)
                {
                    curShape.Remove(canvas, shapesHistory);

                    curShape = new Circle(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
            }

            // Удаление последней фигуры
            if (e.Key == Key.Z && Keyboard.IsKeyDown(Key.LeftCtrl) && canvas.Children.Count != 0)
            {
                shapesHistory.Last().Remove(canvas, shapesHistory);

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
                    curShape.Remove(canvas, shapesHistory);

                    curShape = new Rectangle(curShape);
                    curShape.Draw(canvas, shapesHistory);
                }
                if ((bool)ellipse.IsChecked)
                {
                    curShape.Remove(canvas, shapesHistory);

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

                curShape.Move(delta);

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
        
        // Изменение цвета фигур
        private void btnNewColors_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.L))
            {
                shapesHistory.Last().Color = GetRandomColor();
            }

            if (Keyboard.IsKeyDown(Key.B))
            {
                canvas.Background = new SolidColorBrush(GetRandomColor());
            }

            if (!Keyboard.IsKeyDown(Key.B) && !Keyboard.IsKeyDown(Key.L))
            {
                canvas.Background = new SolidColorBrush(GetRandomColor());
                foreach (Shape shape in shapesHistory)
                {
                    shape.Color = GetRandomColor();
                }
            }
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
        private void hexagon_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new HexagonCreator();
        }
        private void star_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new StarCreator();
        }
        private void randomShape_Checked(object sender, RoutedEventArgs e)
        {
            curCreator = new RandomCreator();
        }

        // Сохранение рисонка в png формате
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveDilog();
        }

        private void SaveDilog()
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                FileName = "Picture.png",
                DefaultExt = ".png",
                Filter = "Images|*.png"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                SavePicture(dlg.FileName);
            }
        }

        private void SavePicture(string fileName)
        {
            BitmapSource img = ToBitmapSource(canvas);
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                encoder.Save(fileStream);
            }
        }

        private BitmapSource ToBitmapSource(FrameworkElement obj)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)obj.ActualWidth, (int)obj.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(obj);
            return bmp;
        }
    }
}
