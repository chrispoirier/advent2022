namespace part1
{
    class File
    {
        public string Label { get; }
        public int Size { get; }

        public File(string label, int size)
        {
            Label = label;
            Size = size;
        }
    }
}
