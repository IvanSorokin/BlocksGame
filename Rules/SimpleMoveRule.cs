using BoxGame.Objects;

namespace BoxesGame
{
    public class SimpleMoveRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return (state.InteractionObject is Space ||
                    state.InteractionObject is Pit) &&
                        state.InteractingObject is Hero;
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractingObject.WithBottom(state.InteractionObject),
                NextToInteractionObject = state.NextToInteractionObject
            };
        }
    }
}