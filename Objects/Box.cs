namespace BoxGame.Objects
{
    public class Box : GameObject
    {
        public override char Symbol => '#';

        public override GameObject ReCreate() => new Box();
    }
}