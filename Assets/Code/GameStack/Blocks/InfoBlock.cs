using Assets.Code.States;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class InfoBlock : IBlock
    {
        private string _interruptMessage = "Not interrupted!";
        private GameManager _manager;

        public InfoBlock(GameManager manager)
        {
            _manager = manager;
        }


        public string InterruptMessage
        {
            get { return _interruptMessage; }
            set { _interruptMessage = value; }

        }

        public void PreInterrupt()
        {
            Debug.Log("Popped an info block.");
        }

        public void PostInterrupt()
        {
            Debug.Log(InterruptMessage);
        }
    }
}