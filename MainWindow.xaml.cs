using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace WPFLABA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Shape> shapes;
        private ShapeSaveHelper shapeSaveHelper;
        public MainWindow()
        {
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();

            try
            {
                shapeSaveHelper = ShapeSaveHelper.GetInstance();
                shapeSaveHelper.Init(new JsonShapeReadWriter(JsonShapeReadWriter.DefaultDataCatalog));
                shapes = shapeSaveHelper.LoadShapes();
                shapeList.ItemsSource = shapes;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            Closed += MainWindowClosed;
        }

        private void AddCircle(object sender, RoutedEventArgs e)
        {
            AddCircleWindow window = new AddCircleWindow();
            try
            {
                if (window.ShowDialog() != true)
                    return;

                AddShape(new Circle(window.Center, window.Radius));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void AddSquare(object sender, RoutedEventArgs e)
        {
            AddSquareWindow window = new AddSquareWindow();
            try
            {
                if (window.ShowDialog() != true)
                    return;

                AddShape(new Square(window.TopLeftPoint, window.Edge));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddTriangle(object sender, RoutedEventArgs e)
        {
            AddTriangleWindow window = new AddTriangleWindow();
            try
            {
                if (window.ShowDialog() != true)
                    return;

                AddShape(new Triangle(window.PointA, window.PointB, window.PointC));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddRectangle(object sender, RoutedEventArgs e)
        {
            AddRectangleWindow window = new AddRectangleWindow();
            try
            {
                if (window.ShowDialog() != true)
                    return;

                AddShape(new Rectangle(window.TopLeftPoint, window.Height, window.Width));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveShape(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected())
            {
                int selectedItemIndex = shapeList.SelectedIndex;
                shapes.RemoveAt(selectedItemIndex);
                MessageBox.Show($"Shape number {selectedItemIndex + 1} was deleted");
            }
        }

        private void MoveTop(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected()) { 
                if(shapeList.SelectedIndex != 0)
                {
                    int selectedItemIndex = shapeList.SelectedIndex;
                    
                    var tempItem = shapes[shapeList.SelectedIndex];        
                    shapes[selectedItemIndex] = shapes[selectedItemIndex - 1];
                    shapes[selectedItemIndex - 1] = tempItem;
                    shapeList.SelectedIndex = selectedItemIndex - 1;
                } 
            }
        }

        private void MoveDown(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected())
            {
                if (shapeList.SelectedIndex != shapeList.Items.Count -1 )
                {
                    int selectedItemIndex = shapeList.SelectedIndex;

                    var tempItem = shapes[shapeList.SelectedIndex];
                    shapes[selectedItemIndex] = shapes[selectedItemIndex + 1];
                    shapes[selectedItemIndex + 1] = tempItem;
                    shapeList.SelectedIndex = selectedItemIndex + 1;
                }
            }
        }
        private bool IsItemSelected()
        {
            return shapeList.SelectedItem != null;
        }


        private void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }


        private void MainWindowClosed(object sender, EventArgs e)
        {
            try
            {
                shapeSaveHelper.SaveShapes(shapes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Shapes was not saved {ex.Message}");
            }
            
        }

    }



}
