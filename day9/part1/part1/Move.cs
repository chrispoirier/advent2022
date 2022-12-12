using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace part1
{
    internal class Move
    {
        internal enum MoveDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        internal MoveDirection Direction { get; set; }
        internal int Count { get; set; }

        internal Move(MoveDirection direction, int count)
        {
            Direction = direction;
            Count = count;
        }

        internal static Move? FromString(string str)
        {
            var exp = new Regex("([UDLR]) (\\d+)");
            var match = exp.Match(str);
            if(match != null)
            {
                return new Move(CharToDirection(match.Groups[1].Value[0]), Convert.ToInt32(match.Groups[2].Value));
            }
            return null;
        }

        private static MoveDirection CharToDirection(char c)
        {
            switch (c)
            {
                case 'U': return MoveDirection.Up;
                case 'D': return MoveDirection.Down;
                case 'L': return MoveDirection.Left;
                default: return MoveDirection.Right;
            }
        }
    }
}
