namespace BoxGame.Objects
{
    public class BreakableWall : GameObject
    {
        public override char Symbol => '=';

        public override GameObject TryParse(char ch) => ch == Symbol ? new BreakableWall() : null;
    }
}