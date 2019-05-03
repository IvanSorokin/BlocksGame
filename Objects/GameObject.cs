using System;
using System.Linq;

namespace BoxGame.Objects
{
    public abstract class GameObject
    {
        public abstract char Symbol { get; }
        private static readonly GameObject[] knownObjects = new GameObject[]
        {
            new Box(),
            new Hero(),
            new Pit(),
            new Space(),
            new Wall(),
            new Coin(),
            new BreakableWall()
        };

        public abstract GameObject ReCreate();

        private GameObject bottom;
        public GameObject Bottom
        {
            get => bottom ?? new Space();
            private set { bottom = value; }
        }

        public GameObject WithBottom(GameObject bottom)
        {
            Bottom = bottom;
            return this;
        }

        public static GameObject FromChar(char ch)
        {
            var obj = knownObjects.SingleOrDefault(x => x.Symbol == ch)?.ReCreate();
            return obj ?? throw new ArgumentException("Unsupported char");
        }
    }
}