

namespace WPFLABA2
{
    public class Point
    {
        public int X { private set; get; }
        public int Y { private set; get; }

        public Point(int y, int x)
        {
            Y = y;
            X = x;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
