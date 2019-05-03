using BoxGame.Objects;

namespace BoxesGame
{
    public class InteractionState
    {
        public GameObject InteractingObject { get; set; }
        public GameObject InteractionObject { get; set; }
        public GameObject NextToInteractionObject { get; set; }
    }
}