using System;
using System.Linq;

namespace BoxesGame
{
    public class GameEngine
    {
        private readonly Map map;
        private readonly IInteractionRule[] rules;
        private Vector heroPosition;

        public GameEngine(Map map)
        {
            this.map = map;
            heroPosition = map.FindHeroPosition();
            rules = new IInteractionRule[]
            {
                new SimpleMoveRule(),
                new SimpleBoxMoveRule()
            };
        }

        private Vector ParseDirection(char ch)
        {
            switch (ch)
            {
                case 'w':
                    return new Vector(-1, 0);
                case 's':
                    return new Vector(1, 0);
                case 'a':
                    return new Vector(0, -1);
                case 'd':
                    return new Vector(0, 1);
                default:
                    return null;
            }
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine(map.ToFrame());
            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                var possibleDirection = ParseDirection(key);

                if (possibleDirection != null && TryMoveHero(possibleDirection))
                {
                    Console.Clear();
                    Console.WriteLine(map.ToFrame());
                    if (WinConditionFound())
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                }
            }
        }

        private bool WinConditionFound()
        {
            for (var i = 0; i < map.Width; i++)
                for (var j = 0; j < map.Height; j++)
                {
                    var obj = map.Get(i, j);
                    if (obj.Type == GameObjectType.Box && obj.Bottom.Type != GameObjectType.Pit)
                        return false;
                }
            return true;
        }

        private bool TryMoveHero(Vector direction)
        {
            var hero = map.Get(heroPosition.X, heroPosition.Y);
            var interactionObject = map.Get(heroPosition.X + direction.X, heroPosition.Y + direction.Y);
            var nextObject = map.Get(heroPosition.X + direction.X * 2, heroPosition.Y + direction.Y * 2);

            var state = new InteractionState
            {
                InteractingObject = hero,
                InteractionObject = interactionObject,
                NextObject = nextObject
            };

            var rule = rules.SingleOrDefault(x => x.CanBeApplied(state));

            if (rule != null)
            {
                var result = rule.GetResolveState(state);
                map.Set(heroPosition.X, heroPosition.Y, result.InteractingObject);
                map.Set(heroPosition.X + direction.X, heroPosition.Y + direction.Y, result.InteractionObject);
                map.Set(heroPosition.X + direction.X * 2, heroPosition.Y + direction.Y * 2, result.NextObject);
                heroPosition = new Vector(heroPosition.X + direction.X, heroPosition.Y + direction.Y);
                return true;
            }

            return false;
        }
    }
}