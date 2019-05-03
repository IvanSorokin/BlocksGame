namespace BoxGame.Objects
{
    public class Hero : GameObject
    {
        public Hero()
        {
            State = new HeroState();
        }

        public override char Symbol => '@';

        public override GameObject TryParse(char ch) => ch == Symbol ? new Hero { State = new HeroState() } : null;

        public HeroState State { get; set; }
    }
}