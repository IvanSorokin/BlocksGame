using BoxGame.Objects;

namespace BoxesGame
{
    public class CoinRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return state.InteractionObject is Coin &&
                   state.InteractingObject is Hero;
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            (state.InteractingObject as Hero).State.CoinCount++;
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractingObject,
                NextToInteractionObject = state.NextToInteractionObject
            };
        }
    }
}