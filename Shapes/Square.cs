using System;


namespace WPFLABA2
{
    class Square : Shape
    {
        public Point TopLeftPoint { private set; get; }
        public int Edge { private set; get; }

        //Создаем квадрат по координатам верхней левой точки и длине стороны
        public Square() { }
        public Square(Point topLeftPoint, int edge)
        {   
            if (edge <= 0)
                throw new ArgumentException();
            TopLeftPoint = topLeftPoint ?? throw new ArgumentNullException(nameof(topLeftPoint));
            Edge = edge;
        }

        public override double CalcArea()
        {
            return Edge * Edge;
        }

        public override double CalcPerimeter()
        {
            return Edge*4;
        }

        public override string ToString()
        {
            return $"Square: Top Left Point({TopLeftPoint.ToString()}), Edge {Edge}";
        }
    }
}
