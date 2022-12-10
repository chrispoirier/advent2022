using System.Collections.Generic;
using System.Threading.Tasks;

namespace part2
{
    internal static class InputProvider
    {
        internal static async Task<List<string>> GetFileLines(string filename)
        {
            return new List<string>(await System.IO.File.ReadAllLinesAsync(filename));
        }
    }
}
