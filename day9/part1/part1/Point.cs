using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point source)
        {
            X = source.X;
            Y = source.Y;
        }

        public static Point Empty
        {
            get
            {
                return new Point(0, 0);
            }
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Point) || obj == null) return false;
            var pt = obj as Point;
            return X == pt.X && Y == pt.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Y.GetHashCode();
        }
    }
}
