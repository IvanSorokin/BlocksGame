using BoxGame.Objects;

namespace BoxesGame
{
    public class SimpleBoxMoveRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return state.InteractionObject is Box &&
                   state.InteractingObject is Hero &&
                   (
                        state.NextToInteractionObject is Space ||
                        state.NextToInteractionObject is Pit
                   );
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractionObject is Box
                                    ? state.InteractingObject.WithBottom(state.InteractionObject.Bottom)
                                    : state.InteractingObject.WithBottom(state.InteractionObject),
                NextToInteractionObject = state.InteractionObject.WithBottom(state.NextToInteractionObject)
            };
        }
    }
}