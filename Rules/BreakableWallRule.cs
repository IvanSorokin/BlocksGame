using BoxGame.Objects;

namespace BoxesGame
{
    public class BreakableWallRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return state.InteractionObject is BreakableWall &&
                   (state.InteractingObject as Hero)?.State?.CoinCount - 1 >= 0;
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            (state.InteractingObject as Hero).State.CoinCount--;
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractingObject,
                NextToInteractionObject = state.NextToInteractionObject
            };
        }
    }
}