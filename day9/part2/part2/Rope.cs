using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    internal class Rope
    {
        private const int NUM_KNOTS = 10;

        internal LinkedList<Point> Knots { get; set; }

        internal Point HeadPos
        {
            get
            {
                return Knots.First();
            }
        }

        internal Point TailPos
        {
            get
            {
                return Knots.Last();
            }
        }

        internal Rope()
        {
            Knots = new LinkedList<Point>();
            for(int i=0; i<NUM_KNOTS; i++)
            {
                Knots.AddLast(Point.Empty);
            }
        }

        internal List<Point> MoveHead(Move move)
        {
            var points = new List<Point>();
            switch(move.Direction)
            {
                case Move.MoveDirection.Up:
                    for(int i=0; i < move.Count; i++) 
                    {
                        var tailPoint = MoveUp();
                        if (tailPoint != null) points.Add(new Point(tailPoint));
                    }
                    break;
                case Move.MoveDirection.Down:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveDown();
                        if (tailPoint != null) points.Add(new Point(tailPoint));
                    }
                    break;
                case Move.MoveDirection.Left:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveLeft();
                        if (tailPoint != null) points.Add(new Point(tailPoint));
                    }
                    break;
                default:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveRight();
                        if (tailPoint != null) points.Add(new Point(tailPoint));
                    }
                    break;
            }
            return points;
        }

        private Point? MoveUp()
        {
            HeadPos.Y += 1;
            if (!IsNextAdjacent())
            {
                return PlayCatchUp();
            }
            return null;
        }

        private Point? MoveDown()
        {
            HeadPos.Y -= 1;
            if (!IsNextAdjacent())
            {
                return PlayCatchUp();
            }
            return null;
        }

        private Point? MoveLeft()
        {
            HeadPos.X -= 1;
            if (!IsNextAdjacent())
            {
                return PlayCatchUp();
            }
            return null;
        }

        private Point? MoveRight()
        {
            HeadPos.X += 1;
            if (!IsNextAdjacent())
            {
                return PlayCatchUp();
            }
            return null;
        }

        private bool IsNextAdjacent(LinkedListNode<Point>? point = null)
        {
            point ??= Knots.First;
            if (point == null || point.Next == null) return true;
            return ArePointsAdjacent(point.Value, point.Next.Value);
        }

        private static bool ArePointsAdjacent(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1;
        }

        private Point PlayCatchUp(LinkedListNode<Point>? point = null)
        {
            point ??= Knots.First;
            if (point == null) return Point.Empty;

            var nextPoint = point.Next;
            if (nextPoint == null) return point.Value;

            if (ArePointsAdjacent(point.Value, nextPoint.Value) && Knots.Last != null) return Knots.Last.Value;

            if (point.Value.X > nextPoint.Value.X)
            {
                nextPoint.ValueRef.X += 1;
            }
            else if(point.Value.X < nextPoint.Value.X)
            {
                nextPoint.ValueRef.X -= 1;
            }
            if(point.Value.Y > nextPoint.Value.Y)
            {
                nextPoint.ValueRef.Y += 1;
            }
            else if(point.Value.Y < nextPoint.Value.Y)
            {
                nextPoint.ValueRef.Y -= 1;
            }
            return PlayCatchUp(nextPoint);
        }

        internal void PrintKnots()
        {
            Console.Write("[");
            var knot = Knots.First;
            while (knot != null) {
                Console.Write(knot.Value);
                Console.Write(',');
                knot = knot.Next;
            }
            Console.WriteLine(']');
        }
    }
}
