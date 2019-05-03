namespace BoxGame.Objects
{
    public class Wall : GameObject
    {
        public override char Symbol => '*';

        public override GameObject ReCreate() => new Wall();
    }
}