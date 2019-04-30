namespace BoxesGame
{
    public class SimpleMoveRule : IInteractionRule
    {
        public bool CanBeApplied(InteractionState state)
        {
            return (state.InteractionObject.Type == GameObjectType.Space || 
                    state.InteractionObject.Type == GameObjectType.Pit) &&
                        state.InteractingObject.Type == GameObjectType.Hero;
        }

        public InteractionState GetResolvedState(InteractionState state)
        {
            return new InteractionState
            {
                InteractingObject = state.InteractingObject.Bottom,
                InteractionObject = GameObject.Hero.WithBottom(state.InteractionObject),
                NextObject = state.NextObject
            };
        }
    }
}