using System;
using System.Windows;

namespace AreaCalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HideInputFields();
        }

        private void HideInputFields()
        {
            SideALabel.Visibility = Visibility.Collapsed;
            SideAInput.Visibility = Visibility.Collapsed;
            SideBLabel.Visibility = Visibility.Collapsed;
            SideBInput.Visibility = Visibility.Collapsed;
            SideCLabel.Visibility = Visibility.Collapsed;
            SideCInput.Visibility = Visibility.Collapsed;
            RadiusLabel.Visibility = Visibility.Collapsed;
            RadiusInput.Visibility = Visibility.Collapsed;
        }

        private void ShapeSelectionChanged(object sender, RoutedEventArgs e)
        {
            HideInputFields();

            if (RectangleRadio.IsChecked == true)
            {
                SideALabel.Visibility = SideAInput.Visibility = Visibility.Visible;
                SideBLabel.Visibility = SideBInput.Visibility = Visibility.Visible;
            }
            else if (CircleRadio.IsChecked == true)
            {
                RadiusLabel.Visibility = RadiusInput.Visibility = Visibility.Visible;
            }
            else if (TriangleRadio.IsChecked == true)
            {
                SideALabel.Visibility = SideAInput.Visibility = Visibility.Visible;
                SideBLabel.Visibility = SideBInput.Visibility = Visibility.Visible;
                SideCLabel.Visibility = SideCInput.Visibility = Visibility.Visible;
            }
        }

        private void CalculateArea(object sender, RoutedEventArgs e)
        {
            double area = 0;
            try
            {
                if (RectangleRadio.IsChecked == true)
                {
                    double a = double.Parse(SideAInput.Text);
                    double b = double.Parse(SideBInput.Text);
                    if (a <= 0 || b <= 0)
                    {
                        MessageBox.Show("Длины сторон должны быть положительными числами!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    area = a * b;
                }
                else if (CircleRadio.IsChecked == true)
                {
                    double r = double.Parse(RadiusInput.Text);
                    if (r <= 0)
                    {
                        MessageBox.Show("Радиус должен быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    area = Math.PI * r * r;
                }
                else if (TriangleRadio.IsChecked == true)
                {
                    double a = double.Parse(SideAInput.Text);
                    double b = double.Parse(SideBInput.Text);
                    double c = double.Parse(SideCInput.Text);
                    if (a <= 0 || b <= 0 || c <= 0)
                    {
                        MessageBox.Show("Стороны треугольника должны быть положительными числами!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (a + b <= c || a + c <= b || b + c <= a)
                    {
                        MessageBox.Show("Треугольник с такими сторонами не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    double s = (a + b + c) / 2;
                    area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                }

                if (area > 0)
                {
                    ResultLabel.Content = area.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Ошибка вычисления площади!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
