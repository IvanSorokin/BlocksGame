namespace BoxesGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = Map.ReadFromFile("map.txt");
            var engine = new GameEngine(map);
            engine.Start();
        }
    }
}