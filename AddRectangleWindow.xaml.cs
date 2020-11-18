using System;
using System.Windows;

namespace WPFLABA2
{
    /// <summary>
    /// Логика взаимодействия для AddRectangleWindow.xaml
    /// </summary>
    public partial class AddRectangleWindow : Window
    {
        public AddRectangleWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int Width
        {
            get
            {
                return Convert.ToInt32(width.Text);
            }
        }

        public int Height
        {
            get
            {
                return Convert.ToInt32(height.Text);
            }
        }

        public Point TopLeftPoint
        {
            get
            {
                return new Point(Convert.ToInt32(xCoord.Text),
                    Convert.ToInt32(yCoord.Text));
            }
        }
    }
}
