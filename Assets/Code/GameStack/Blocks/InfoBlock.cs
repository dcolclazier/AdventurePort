using UnityEngine;

namespace Assets.Code.Scripts
{
    public class InfoBlock : IBlock
    {
        private string _interruptMessage = "Not interrupted!";
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