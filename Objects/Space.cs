namespace BoxGame.Objects
{
    public class Space : GameObject
    {
        public override char Symbol => ' ';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Space() : null;
    }
}