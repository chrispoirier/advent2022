using System;
using System.Text.RegularExpressions;

namespace part2
{
    enum CommandType
    {
        CdUp,
        CdDir,
        Ls,
        Dir,
        File
    }
    internal class Command
    {
        private static readonly Regex cdUpExp = new Regex("\\$ cd \\.\\.");
        private static readonly Regex cdDirExp = new Regex("\\$ cd (.+)");
        private static readonly Regex lsExp = new Regex("\\$ ls");
        private static readonly Regex dirExp = new Regex("dir (.+)");
        private static readonly Regex fileExp = new Regex("(\\d+) (.+)");

        public CommandType Type { get; set; }
        public string Label { get; set; }
        public int? Size { get; set; }

        internal static Command FromLine(string line)
        {
            if (cdUpExp.IsMatch(line))
            {
                return new Command(CommandType.CdUp, null, null);
            }
            if (cdDirExp.IsMatch(line))
            {
                return new Command(CommandType.CdDir, GetLabel(CommandType.CdDir, line), null);
            }
            if (lsExp.IsMatch(line))
            {
                return new Command(CommandType.Ls, null, null);
            }
            if (dirExp.IsMatch(line))
            {
                return new Command(CommandType.Dir, GetLabel(CommandType.Dir, line), null);
            }
            if (fileExp.IsMatch(line))
            {
                return new Command(CommandType.File, GetLabel(CommandType.File, line), GetSize(line));
            }
            return null;
        }

        public Command(CommandType type, string label, int? size)
        {
            Type = type;
            Label = label;
            Size = size;
        }

        private static string GetLabel(CommandType type, string line)
        {
            switch (type)
            {
                case CommandType.CdDir:
                    var cdDirMatch = cdDirExp.Match(line);
                    if (cdDirMatch != null)
                    {
                        return cdDirMatch.Groups[1].Value;
                    }
                    break;
                case CommandType.Dir:
                    var dirMatch = dirExp.Match(line);
                    if (dirMatch != null)
                    {
                        return dirMatch.Groups[1].Value;
                    }
                    break;
                case CommandType.File:
                    var fileMatch = fileExp.Match(line);
                    if (fileMatch != null)
                    {
                        return fileMatch.Groups[2].Value;
                    }
                    break;
            }
            return string.Empty;
        }

        private static int? GetSize(string line)
        {
            var fileMatch = fileExp.Match(line);
            if (fileMatch != null)
            {
                return Convert.ToInt32(fileMatch.Groups[1].Value);
            }

            return null;
        }
    }
}