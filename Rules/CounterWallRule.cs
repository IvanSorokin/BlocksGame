using BoxGame.Objects;

namespace BoxesGame
{
    public class CounterWallRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return state.InteractionObject is CounterWall &&
                   state.InteractingObject is Hero;
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            var decreasedCounterWall = new CounterWall((state.InteractionObject as CounterWall).Count - 1);
            var bottom = decreasedCounterWall.Count > 0 ? decreasedCounterWall as GameObject : new Wall() as GameObject;
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractingObject.WithBottom(bottom),
                NextObject = state.NextObject
            };
        }
    }
}