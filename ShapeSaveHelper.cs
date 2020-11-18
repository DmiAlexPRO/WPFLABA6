using System;
using System.Collections.ObjectModel;

namespace WPFLABA2
{
    class ShapeSaveHelper
    {
        private static ShapeSaveHelper instance;
        private ShapeReadWriter readWriter;
        private ShapeSaveHelper(){}

        public static ShapeSaveHelper GetInstance()
        {
            if (instance is null)
                instance =  new ShapeSaveHelper();
            return instance;
        }
        public void Init(ShapeReadWriter readWriter)
        {
            this.readWriter = readWriter;
        }

        public void SaveShapes(ObservableCollection<Shape> shapes)
        {
            readWriter.Write(shapes);
        }

        public ObservableCollection<Shape> LoadShapes()
        {
            if (readWriter is null)
                throw new Exception("ShapeReadWriter was not initialised use method 'init'");

            try
            {
                return readWriter.Read();
            }
            catch (Exception)
            {
                return new ObservableCollection<Shape>();
            }
        }

    }
}
