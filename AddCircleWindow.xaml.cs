using System;
using System.Windows;

namespace WPFLABA2
{
    /// <summary>
    /// Логика взаимодействия для AddCircleWindow.xaml
    /// </summary>
    public partial class AddCircleWindow : Window
    {
        public AddCircleWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public int Radius
        {
            get
            {
                return Convert.ToInt32(radius.Text);
            }
        }

        public Point Center
        {
            get
            {
                return new Point(Convert.ToInt32(xCoord.Text),
                    Convert.ToInt32(yCoord.Text));
            }
        }
    }
}
