namespace BoxGame.Objects
{
    public class CounterWall : GameObject
    {
        public int Count { get; }

        public CounterWall(int count)
        {
            this.Count = count;
            this.Symbol = count.ToString()[0];
        }

        public override char Symbol { get; }

        public override GameObject TryParse(char ch) => int.TryParse(ch.ToString(), out int c) ? new CounterWall(c) : null;
    }
}