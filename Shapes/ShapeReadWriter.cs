
using System.Collections.ObjectModel;

namespace WPFLABA2
{
    interface ShapeReadWriter
    {
        void Write(ObservableCollection<Shape> shapes);
        ObservableCollection<Shape> Read();
    }
}
