using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class Game
    {
        internal Rope Rope { get; set; }
        internal List<Move> Moves { get; set; }
        internal HashSet<Point> TailVisited { get; set; }

        internal Game(List<string> movesStr) 
        {
            Rope = new Rope(Point.Empty, Point.Empty);
            Moves = new List<Move>();
            InitMoves(movesStr);
            TailVisited = new HashSet<Point>() { Point.Empty };
        }

        private void InitMoves(List<string> movesStr)
        {
            foreach(var moveStr in movesStr)
            {
                var move = Move.FromString(moveStr);
                if(move != null) Moves.Add(move);
            }
        }

        internal int Run()
        {
            foreach(var move in Moves)
            {
                var tailVisited = Rope.MoveHead(move);
                //Console.WriteLine($"H: ({Rope.HeadPos.X},{Rope.HeadPos.Y}) | T: ({Rope.TailPos.X},{Rope.TailPos.Y})");
                //Console.WriteLine("tv: [" + String.Join(';', tailVisited) + "]");
                if (tailVisited != null)
                {
                    foreach(var visPoint in tailVisited)
                    {
                        TailVisited.Add(visPoint);
                    }
                }
                //Console.WriteLine("TV: [" + String.Join(';', TailVisited) + "]\n");
            }
            return TailVisited.Count;
        }
    }
}
