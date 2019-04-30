namespace BoxesGame
{
    public class SimpleBoxMoveRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return state.InteractionObject.Type == GameObjectType.Box &&
                   state.InteractingObject.Type == GameObjectType.Hero &&
                   (
                        state.NextObject.Type == GameObjectType.Space ||
                        state.NextObject.Type == GameObjectType.Pit
                   );
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = state.InteractionObject.Type == GameObjectType.Box
                                    ? GameObject.Hero.WithBottom(state.InteractionObject.Bottom)
                                    : GameObject.Hero.WithBottom(state.InteractionObject),
                NextObject = GameObject.Box.WithBottom(state.NextObject)
            };
        }
    }
}