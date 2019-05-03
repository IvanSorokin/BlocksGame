namespace BoxGame.Objects
{
    public class Coin : GameObject
    {
        public override char Symbol => '$';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Coin() : null;
    }
}