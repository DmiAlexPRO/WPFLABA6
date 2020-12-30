using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WPFLABA2
{
    class JsonShapeReadWriter : ShapeReadWriter
    {
        public const string DefaultDataCatalog = ".\\data.json";
        private Logger logger = LogManager.GetCurrentClassLogger();
        private string dataCatalog;

        public JsonShapeReadWriter(string catalog)
        {
            if (string.IsNullOrEmpty(catalog))
                throw new ArgumentException($"{nameof(catalog)} не может быть пустым или иметь значение null", nameof(catalog));

            dataCatalog = catalog;
        }

        public ObservableCollection<Shape> Read()
        {
            ObservableCollection<Shape> shapes;
            FileInfo file = new FileInfo(dataCatalog);

            if (!file.Exists)
            {
                logger.Error("File doesn't exist or file can't be read");
                throw new FileNotFoundException("File doesn't exist or file can't be read");
            }

            try
            {
                string readJson = File.ReadAllText(dataCatalog);
                shapes = new ObservableCollection<Shape>();
                var readShapes = (JsonConvert.DeserializeObject<List<Shape>>(readJson, new ShapeConverter()));
                foreach(var shape in readShapes)
                {
                    shapes.Add(shape);
                }
                
                    
        }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
            logger.Info("File read");
            return shapes;
        }

        public void Write(ObservableCollection<Shape> shapes)
        {
            if (shapes is null)
            {
                logger.Debug($"{nameof(shapes)} не может иметь значение null", nameof(shapes));
                throw new ArgumentNullException(nameof(shapes));
            } 

            try
            {
                string json = JsonConvert.SerializeObject(shapes);
                using (StreamWriter streamWriter = new System.IO.StreamWriter(dataCatalog))
                {
                    streamWriter.WriteLine(json);
                }
                logger.Info("File written");
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }
        }


        private class ShapeConverter : CustomCreationConverter<Shape>
        {
            public override Shape Create(Type objectType)
            {
                //Type t = objectType.GetType();
                if (CanConvert(typeof(Circle)))
                {
                    return new Circle();
                }
                else if(CanConvert(typeof(Triangle)))
                {
                    return new Triangle();
                }
                else if (CanConvert(typeof(Square)))
                {
                    return new Square();
                }
                else if (CanConvert(typeof(Rectangle)))
                {
                    return new Rectangle();
                }
                else
                {
                    throw new ArgumentException("Not all new shapes have been added to this method");
                }
            }


        }

    }
}
