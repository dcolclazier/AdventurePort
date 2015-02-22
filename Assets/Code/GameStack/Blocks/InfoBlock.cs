using UnityEngine;

namespace Assets.Code.Scripts
{
    public class InfoBlock : IBlock
    {
        public void PreInterrupt()
        {
            Debug.Log("Popped an info block.");
        }

        public void PostInterrupt()
        {
            Debug.Log("Well shit.. I was interrupted.");
        }
    }
}