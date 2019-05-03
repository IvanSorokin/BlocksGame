namespace BoxGame.Objects
{
    public class Box : GameObject
    {
        public override char Symbol => '#';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Box() : null;
    }
}