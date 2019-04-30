
using System;

namespace BoxesGame
{
    public class GameObject
    {
        public GameObject(char symbol, GameObjectType type)
        {
            Symbol = symbol;
            Type = type;
        }

        public char Symbol { get; }
        public GameObjectType Type { get; }

        private GameObject bottom;
        public GameObject Bottom
        {
            get => bottom ?? GameObject.Space;
            private set { bottom = value; }
        }

        public GameObject WithBottom(GameObject bottom)
        {
            Bottom = bottom;
            return this;
        }

        public static GameObject Wall => new GameObject('*', GameObjectType.Wall);
        public static GameObject Box => new GameObject('#', GameObjectType.Box);
        public static GameObject Space => new GameObject(' ', GameObjectType.Space);
        public static GameObject Hero => new GameObject('@', GameObjectType.Hero);
        public static GameObject Pit => new GameObject('o', GameObjectType.Pit);

        public static GameObject FromChar(char ch)
        {
            if (ch == Wall.Symbol)
                return Wall;
            if (ch == Box.Symbol)
                return Box;
            if (ch == Space.Symbol)
                return Space;
            if (ch == Hero.Symbol)
                return Hero;
            if (ch == Pit.Symbol)
                return Pit;

            throw new ArgumentException("Unsupported char");
        }
    }
}