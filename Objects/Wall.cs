namespace BoxGame.Objects
{
    public class Wall : GameObject
    {
        public override char Symbol => '*';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Wall() : null;
    }
}