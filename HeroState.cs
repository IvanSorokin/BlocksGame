namespace BoxGame
{
    public class HeroState
    {
        public int CoinCount { get; set; }

        public override string ToString() => $"Coin count {CoinCount}";
    }
}