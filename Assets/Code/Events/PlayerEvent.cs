using Assets.Code.States;

namespace Assets.Code.Scripts
{
    public sealed class PlayerEvent : IEvent
    {
        private static PlayerEvent _instance;
        public static PlayerEvent Triggers { get { return _instance ?? (_instance = new PlayerEvent()); } }

        private PlayingGameState _gameState;
        public PlayerEvent()
        {

        }

        public void Update()
        {

            //If there is a player tag that isn't in our list, add it.
            //
            //
            //If any player event occurs, trigger event. Needs to have access to all player entities.. Who
            //has this data? Who should have this data?

            //If mouseOver, triger mouseOver event
            //If mouseExit, trigger mouseExit event

        }

        public event PlayerTrigger MouseEnteredPlayerSpace;
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