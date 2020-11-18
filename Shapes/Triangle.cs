using System;


namespace WPFLABA2
{
    class Triangle : Shape
    {
        public Point PointA {  set; get; }
        public Point PointB {  set; get; }
        public Point PointC { set; get; }

        public Triangle() { }

        //Создаем треугольник по координатам трех точек
        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            if (pointA is null || pointB is null || pointC is null)
                throw new ArgumentNullException();

            double aB = GeomUtils.CalcDistance( pointA, pointB);
            double bC = GeomUtils.CalcDistance(pointB, pointC);
            double aC = GeomUtils.CalcDistance(pointA, pointC);
           
            if ( aB >= bC + aC || bC >= aB + aC || aC >= bC + aB) //проверяем, может ли такой треугольник существовать
                throw new ArgumentException("This triangle cant exist");

            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }

        public override double CalcArea()
        {
            return 0.5 * Math.Abs((PointB.X - PointA.X)*(PointC.Y - PointA.X)-(PointC.X - PointA.X)*(PointB.Y - PointA.Y));
        }

        public override double CalcPerimeter()
        {
            return GeomUtils.CalcDistance(PointA, PointB) + GeomUtils.CalcDistance(PointB, PointC) + GeomUtils.CalcDistance(PointA, PointC);
        }

        public override string ToString()
        {
            return $"Triangle: PointA({PointA.ToString()}), PointB({PointB.ToString()}), PointC({PointC.ToString()}) ";
        }
    }
}
