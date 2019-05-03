namespace BoxGame.Objects
{
    public class Pit : GameObject
    {
        public override char Symbol => 'o';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Pit() : null;
    }
}