using UnityEngine;

namespace Assets.Code.Scripts
{
    public class InfoBlock : IBlock
    {
        public string InterruptMessage
        {
            get { return "Not interrupted!"; }
            set { InterruptMessage = value; }

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