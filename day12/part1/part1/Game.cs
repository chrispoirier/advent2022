namespace part1 {
    internal class Game
    {
        private ElevationMap Map { get; set; }
        private List<Climber> Climbers { get; set; }

        public Game(List<string> list)
        {
            this.Map = ElevationMap.FromData(list);
            this.Climbers= new List<Climber>();
        }

        internal object Run()
        {
            Climbers.Add(new Climber(Map.StartPos));
        }

        public override string ToString()
        {
            return Map.ToString();
        }
    }
}