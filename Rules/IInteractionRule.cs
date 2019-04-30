namespace BoxesGame
{
    public interface IInteractionRule
    {
        bool CanBeApplied(InteractionState state);
        InteractionState GetResolvedState(InteractionState state);
    }
}