namespace BoxGame.Objects
{
    public class Coin : GameObject
    {
        public override char Symbol => '$';

        public override GameObject ReCreate() => new Coin();
    }
}