using System;
using System.Collections.Generic;
using System.Linq;

namespace part1
{
    internal class Directory
    {
        public string Label { get; }
        public List<File> Files { get; set; }
        public List<Directory> Dirs { get; set; }

        internal static Directory FromCommands(List<string> lines)
        {
            var root = new Directory(string.Empty);
            if (lines.Count > 0)
            {
                lines.RemoveAt(0);
                ProcessCommands(lines, root);
            }
            return root;
        }

        private static void ProcessCommands(List<string> lines, Directory root)
        {
            while (lines.Count > 0)
            {
                var command = Command.FromLine(lines[0]);
                lines.RemoveAt(0);
                if (command == null) continue;

                switch (command.Type)
                {
                    case CommandType.Dir:
                        root.Dirs.Add(new Directory(command.Label));
                        break;
                    case CommandType.File:
                        if (command.Size.HasValue)
                        {
                            root.Files.Add(new File(command.Label, command.Size.Value));
                        }
                        break;
                    case CommandType.CdUp:
                        return;
                    case CommandType.CdDir:
                        var cdRoot = root.Dirs.FirstOrDefault(d => d.Label == command.Label);
                        if (cdRoot != null) ProcessCommands(lines, cdRoot);
                        break;

                }
            }
        }

        public Directory(string label)
        {
            Label = label;
            Files = new List<File>();
            Dirs = new List<Directory>();
        }

        internal int SumOfDirsLTE(int lteLimit)
        {
            int dirSize = GetSize();
            int sum = dirSize <= lteLimit ? dirSize : 0;

            foreach (Directory d in Dirs)
            {
                sum += d.SumOfDirsLTE(lteLimit);
            }

            return sum;
        }

        internal void PrintDebug(string seed = "")
        {
            Console.WriteLine(seed + "- " + Label + "/");
            foreach (File f in Files)
            {
                Console.WriteLine(seed + "  + " + f.Label + " (" + f.Size + ")");
            }
            foreach (Directory d in Dirs)
            {
                d.PrintDebug(seed + "  ");
            }
        }

        private int GetSize()
        {
            int size = 0;
            foreach (var d in Dirs)
            {
                size += d.GetSize();
            }
            foreach (var f in Files)
            {
                size += f.Size;
            }
            return size;
        }
    }
}
