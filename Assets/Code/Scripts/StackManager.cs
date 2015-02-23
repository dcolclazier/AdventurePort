using UnityEngine;

namespace Assets.Code.Scripts
{
    public class StackManager
    {

        //private static StackManager _instance;
        //public static StackManager Instance { get { return _instance ?? new StackManager(); } }
        private GameStack Stack { get; set; }

        public event StackAction Interrupt;

        public StackManager()
        {
            Stack = new GameStack();
        }

        public void PushToStack(IBlock block)
        {
            Stack.Push(block);
        }

        public void PopStack()
        {
            var blockToExecute = Stack.Pop();                   //Get the block to be "popped"
            blockToExecute.PreInterrupt();                          //Perform the stack's pre-interrupt actions
            if(Interrupt != null) Interrupt.Invoke(blockToExecute); //Any interrupts should be subscribed to the interrupt event - these actions occur now.
            blockToExecute.PostInterrupt();                         // Block performs rest of actions, post-interrupt.
        }


    }
}