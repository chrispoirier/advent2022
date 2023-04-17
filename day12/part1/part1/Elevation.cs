namespace part1
{
    internal class Elevation
    {
        public char Value { get; set; }
        public bool IsStart { get; set; } = false;
        public bool IsEnd { get; set; } = false;
        public bool Visited { get; set; } = false;

        public Elevation(char elev)
        {
            switch (elev)
            {
                case 'S':
                    Value = 'a';
                    IsStart = true;
                    break;
                case 'E':
                    Value = 'z';
                    IsEnd = true;
                    break;
                default:
                    Value = elev;
                    break;
            }
        }

        public override string ToString()
        {
            if(Visited)
            {
                return ".";
            }
            if(IsStart)
            {
                return "S";
            }
            if(IsEnd)
            {
                return "E";
            }
            return Value.ToString();
        }
    }
}