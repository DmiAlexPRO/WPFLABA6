using System;


namespace WPFLABA2
{
    class Rectangle : Shape
    {
        public Point TopLeftPoint {  set; get; }
        public int Height {  set; get; }
        public int Width {  set; get; }

        public Rectangle() { }
        //Создаем прямоугольник по координатам верхней левой точки и длинам двух сторон
        public Rectangle(Point topLeftPoint, int height, int width)
        {
            if ( width <= 0 || height <= 0)
                throw new ArgumentException();

            TopLeftPoint = topLeftPoint ?? throw new ArgumentNullException(nameof(topLeftPoint));
            Width = width;
            Height = height;
           
        }

        public override double CalcArea()
        {
            return Width * Height;
        }

        public override double CalcPerimeter()
        {
            return (Width + Height) * 2;
        }

        public override string ToString()
        {
            return $"Rectangle: Top Left Point({TopLeftPoint.ToString()}), Height {Height}, Width {Width}";
        }
    }
}
