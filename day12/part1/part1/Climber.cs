using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class Climber
    {
        private Tuple<int, int> CurrentPos { get; set; }

        public Climber(Tuple<int, int> startPos)
        {
            CurrentPos = startPos;
        }
    }
}
