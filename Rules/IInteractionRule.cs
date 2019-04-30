namespace BoxesGame
{
    public interface IInteractionRule
    {
        bool CanBeApplied(InteractionState state);
        InteractionState GetResolveState(InteractionState state);
    }
}