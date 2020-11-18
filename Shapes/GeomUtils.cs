using System;

namespace WPFLABA2

{
    class GeomUtils
    {   
        //вычисляет расстояние между двумя точками
        public static double CalcDistance(Point point1, Point point2)
        {
            if (point1 is null || point2 is null)
            {
                throw new ArgumentNullException();
            }
            return Math.Sqrt(Math.Pow(point2.X-point1.X, 2) + Math.Pow(point2.Y-point1.Y, 2));
        }
    }
}
