using Assets.Code.Abstract.Interfaces;
using Assets.Code.GameObjects._Halo;

namespace Assets.Code.__SKELETONS___DO_NOT_USE
{

    //Skeleton InputEventHandler class ALWAYS Implement IInputEventHandler... You could add functions here like:
    /*
     * public class BaddyInputEventHandler : IInputEventHandler
     * {
     *      public void RightMouseClicked(MouseButton button, Vector3 mousePosition)
            {
                 if (button != MouseButton.Right) return;
     *            
     *           if mouse is currently over baddy, blah blah blah   
                 Do Stuff!
     *      }
     *      public void Initialize() {
                InputEvent.Triggers.MouseClicked += RightMouseClicked;
     *      
     *      }
            public void ClearEvents() {
     *          InputEvent.Triggers.MouseClicked -= RightMouseClicked;
            }
     *      
     * }
     * As long as you put the following line in Initialize(),
     *          InputEvent.Triggers.MouseClicked += RightMouseClicked;
     *   and the following line in ClearEvents(),
     *          InputEvent.Triggers.MouseClicked -= RightMouseClicked;
     *   
     *   the function will automatically be run when the Right Mouse is clicked... Be careful 
     *   to validate the input perfectly, or weird results could occur.
     *   
     * This general format will be the same for ALL game events.. For example, PlayerEvent has been 
     * started, with the mouseEnter and mouseExit events available for whoever needs them. I use these to handle
     * selector halo creation/destruction.
     */
    public class InputEventHandler : IInputEventHandler
    {
        private readonly Halo _halo;

        public InputEventHandler(Halo halo)
        {
            _halo = halo;
        }

        //Mouse input handling. delegate form: void(Mousebutton button, Vector3 mousePosition)
        //InputEvent.Triggers holds different event triggers (only the mouse is currently supported.)
        public void Initialize() {
        }
        public void ClearEvents() {
        }

    }
}