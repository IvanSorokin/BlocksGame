namespace BoxGame.Objects
{
    public class Pit : GameObject
    {
        public override char Symbol => 'o';

        public override GameObject ReCreate() => new Pit();
    }
}