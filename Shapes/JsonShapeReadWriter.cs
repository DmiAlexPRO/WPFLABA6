using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

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
                shapes = (JsonConvert.DeserializeObject<ObservableCollection<Shape>>(readJson, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));            
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show($" {ex.Message}");
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
                string json = JsonConvert.SerializeObject(shapes, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All } );
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

    }
}
