using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class Rope
    {
        private const char HEAD_MARKER = 'H';
        private const char TAIL_MARKER = 'T';

        internal Point HeadPos { get; set; }
        internal Point TailPos { get; set; }

        internal Rope(Point headPos, Point tailPos) 
        {
            HeadPos = headPos;
            TailPos = tailPos;
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
                        if (tailPoint != null) points.Add(tailPoint);
                    }
                    break;
                case Move.MoveDirection.Down:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveDown();
                        if (tailPoint != null) points.Add(tailPoint);
                    }
                    break;
                case Move.MoveDirection.Left:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveLeft();
                        if (tailPoint != null) points.Add(tailPoint);
                    }
                    break;
                default:
                    for (int i = 0; i < move.Count; i++)
                    {
                        var tailPoint = MoveRight();
                        if (tailPoint != null) points.Add(tailPoint);
                    }
                    break;
            }
            return points;
        }

        private Point? MoveUp()
        {
            HeadPos.Y += 1;
            if (!IsTailAdjacent())
            {
                return MoveTailToHead();
            }
            return null;
        }

        private Point? MoveDown()
        {
            HeadPos.Y -= 1;
            if (!IsTailAdjacent())
            {
                return MoveTailToHead();
            }
            return null;
        }

        private Point? MoveLeft()
        {
            HeadPos.X -= 1;
            if (!IsTailAdjacent())
            {
                return MoveTailToHead();
            }
            return null;
        }

        private Point? MoveRight()
        {
            HeadPos.X += 1;
            if (!IsTailAdjacent())
            {
                return MoveTailToHead();
            }
            return null;
        }

        private bool IsTailAdjacent()
        {
            return Math.Abs(HeadPos.X - TailPos.X) <= 1 && Math.Abs(HeadPos.Y - TailPos.Y) <= 1;
        }

        private Point MoveTailToHead()
        {
            if(HeadPos.X > TailPos.X)
            {
                TailPos.X += 1;
            }
            else if(HeadPos.X < TailPos.X)
            {
                TailPos.X -= 1;
            }
            if(HeadPos.Y > TailPos.Y)
            {
                TailPos.Y += 1;
            }
            else if(HeadPos.Y < TailPos.Y)
            {
                TailPos.Y -= 1;
            }
            return new Point(TailPos);
        }
    }
}
