namespace BoxGame.Objects
{
    public class Space : GameObject
    {
        public override char Symbol => ' ';

        public override GameObject ReCreate() => new Space();
    }
}