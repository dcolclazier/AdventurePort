using Assets.Code.Abstract.Interfaces;
using Assets.Code.Delegates;
using Assets.Code.GameObjects.PlayerCharacter;
using Assets.Code.States;

namespace Assets.Code.Events
{
    public sealed class PlayerEvent : IEvent
    {
        private static PlayerEvent _instance;
        public static PlayerEvent Triggers { get { return _instance ?? (_instance = new PlayerEvent()); } }

        public void Update()
        {

        }

        public event PlayerTrigger MouseEnteredPlayerSpace;

        //these should be private, I think...
        public void OnMouseEntered(Player player)
        {
            if (MouseEnteredPlayerSpace != null) MouseEnteredPlayerSpace(player);
        }

        public event PlayerTrigger MouseExitedPlayerSpace;

        public void OnMouseLeft(Player player)
        {
            
            if (MouseExitedPlayerSpace != null) MouseExitedPlayerSpace(player);
        }
    }
}