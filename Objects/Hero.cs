namespace BoxGame.Objects
{
    public class Hero : GameObject
    {
        public Hero()
        {
            State = new HeroState();
        }

        public override char Symbol => '@';

        public override GameObject ReCreate() => new Hero { State = new HeroState() };

        public HeroState State { get; set; }
    }
}