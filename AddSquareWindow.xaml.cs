using System;
using System.Windows;

namespace WPFLABA2
{
    /// <summary>
    /// Логика взаимодействия для AddSquareWindow.xaml
    /// </summary>
    public partial class AddSquareWindow : Window
    {
        public AddSquareWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int Edge
        {
            get
            {
                return Convert.ToInt32(edge.Text);
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
