using System;
using System.Linq;
using BoxGame.Objects;

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
                new SimpleBoxMoveRule(),
                new CoinRule(),
                new BreakableWallRule(),
                new CounterWallRule()
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

        private static void ClearLastOutput()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth * Console.WindowHeight));
            Console.SetCursorPosition(0, 0);
        }

        public void Start()
        {
            RefreshScreen(fullClear: true);

            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                var possibleDirection = ParseDirection(key);

                if (possibleDirection != null && TryMoveHero(possibleDirection))
                {
                    RefreshScreen();

                    if (WinConditionFound())
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                }
            }
        }

        private void RefreshScreen(bool fullClear = false)
        {
            if (fullClear)
                Console.Clear();
            else
                ClearLastOutput();

            Console.WriteLine(map.ToFrame());
            Console.WriteLine((map.Get(heroPosition.X, heroPosition.Y) as Hero).State);
        }

        private bool WinConditionFound()
        {
            for (var i = 0; i < map.Width; i++)
                for (var j = 0; j < map.Height; j++)
                {
                    var obj = map.Get(i, j);
                    if (obj is Box && !(obj.Bottom is Pit))
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
                NextToInteractionObject = nextObject
            };

            var rule = rules.SingleOrDefault(x => x.CanBeApplied(state));

            if (rule != null)
            {
                var result = rule.GetResolvedState(state);
                map.Set(heroPosition.X, heroPosition.Y, result.InteractingObject);
                map.Set(heroPosition.X + direction.X, heroPosition.Y + direction.Y, result.InteractionObject);
                map.Set(heroPosition.X + direction.X * 2, heroPosition.Y + direction.Y * 2, result.NextToInteractionObject);
                heroPosition = new Vector(heroPosition.X + direction.X, heroPosition.Y + direction.Y);
                return true;
            }

            return false;
        }
    }
}