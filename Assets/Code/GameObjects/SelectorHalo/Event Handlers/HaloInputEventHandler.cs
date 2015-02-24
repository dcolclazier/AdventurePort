using Assets.Code.Abstract;
using Assets.Code.Abstract.Interfaces;
using UnityEngine;

namespace Assets.Code.GameObjects.SelectorHalo.Event_Handlers
{
    public class HaloInputEventHandler : IInputEventHandler
    {
        private readonly SelectorHalo _halo;

        public HaloInputEventHandler(SelectorHalo halo)
        {
            _halo = halo;
        }

        //Mouse input handling. void(Mousebutton button, Vector3 mousePosition)
        public void Initialize()
        {
        
        }

        public void ClearEvents()
        {
        
        }

        public void LeftMouseClicked(MouseButton button, Vector3 mousePosition)
        {
            if (button != MouseButton.Left) return;

            //if(_halo.Player.Selected && !_halo.Player.MouseOver)  
        }
   
    }
}