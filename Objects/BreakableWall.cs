namespace BoxGame.Objects
{
    public class BreakableWall : GameObject
    {
        public override char Symbol => '=';

        public override GameObject ReCreate() => new BreakableWall();
    }
}