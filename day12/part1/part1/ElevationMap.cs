using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class ElevationMap
    {
        internal List<List<Elevation>> Elevations { get; set; } = new List<List<Elevation>>();
        internal Tuple<int, int> StartPos { get; set; }
        internal Tuple<int, int> EndPos { get; set; }

        internal static ElevationMap FromData(List<string> grid)
        {
            ElevationMap map = new ElevationMap();

            foreach(var (row, rowIndex) in grid.Select((v, i) => (v, i)))
            {
                List<Elevation> list = new List<Elevation>();
                foreach(var (elev, colIndex) in row.Select((v, i) => (v, i)))
                {
                    var elevation = new Elevation(elev);
                    list.Add(elevation);
                    if(elevation.IsStart)
                    {
                        map.StartPos = new Tuple<int, int>(rowIndex, colIndex);
                    }
                    if(elevation.IsEnd)
                    {
                        map.EndPos = new Tuple<int, int>(rowIndex, colIndex);
                    }
                }
                map.Elevations.Add(list);
            }

            return map;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(List<Elevation> row in Elevations)
            {
                foreach(Elevation e in row)
                {
                    sb.Append(e.ToString());
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
