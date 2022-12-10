using System;
using System.Threading.Tasks;

namespace part2
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var lines = await InputProvider.GetFileLines("input");
            var tree = Directory.FromCommands(lines);
            //tree.PrintDebug();
            //Console.WriteLine();
            Console.WriteLine("Sum of dirs <= 100000: " + tree.SizeOfDeleteDir(30000000 - (70000000 - tree.GetSize())));
        }
    }
}
