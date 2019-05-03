namespace BoxGame.Objects
{
    public class Hero : GameObject
    {
        public override char Symbol => '@';

        public override GameObject ReCreate() => new Hero();
    }
}