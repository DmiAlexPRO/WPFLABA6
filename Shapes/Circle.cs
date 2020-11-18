using System;

namespace WPFLABA2
{
    class Circle : Shape
    {   
        public Point Center {  set; get; }
        public int Radius {  set; get; }

        public Circle() { }
        public Circle(Point center,int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius cant be 0 or below 0");

            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius;
        }

        public override double CalcArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalcPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle: Center({Center.ToString()}), radius {Radius}";
        }

    }
}
