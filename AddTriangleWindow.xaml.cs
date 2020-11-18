using System;
using System.Windows;


namespace WPFLABA2
{
    /// <summary>
    /// Логика взаимодействия для AddTriangleWindow.xaml
    /// </summary>
    public partial class AddTriangleWindow : Window
    {
        public AddTriangleWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
        }

        public Point PointA
        {
            get
            {
                return new Point(Convert.ToInt32(xCoordA.Text),
                    Convert.ToInt32(yCoordA.Text));
            }
        }

        public Point PointB
        {
            get
            {
                return new Point(Convert.ToInt32(xCoordB.Text),
                    Convert.ToInt32(yCoordB.Text));
            }
        }

        public Point PointC
        {
            get
            {
                return new Point(Convert.ToInt32(xCoordC.Text),
                    Convert.ToInt32(yCoordC.Text));
            }
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
