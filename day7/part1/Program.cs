using System;
using System.Threading.Tasks;

namespace part1
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var lines = await InputProvider.GetFileLines("input");
            var tree = Directory.FromCommands(lines);
            tree.PrintDebug();
            Console.WriteLine();
            Console.WriteLine("Sum of dirs <= 100000: " + tree.SumOfDirsLTE(100000));
        }
    }
}
