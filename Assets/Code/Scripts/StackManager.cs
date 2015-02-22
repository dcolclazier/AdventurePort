using UnityEngine;

namespace Assets.Code.Scripts
{
    public class StackManager
    {
        private readonly GameManager _manager;
        private GameStack GameStack { get; set; }

        public event StackAction Interrupt;
        public StackManager(GameManager manager)
        {
            _manager = manager;
            GameStack = new GameStack();
        }

        public void PushToStack(IBlock block)
        {
            GameStack.Push(block);
        }

        public void PopStack()
        {
            var blockToExecute = GameStack.Pop();                   //Get the block to be "popped"
            blockToExecute.PreInterrupt();                          //Perform the stack's pre-interrupt actions
            if(Interrupt != null) Interrupt.Invoke(blockToExecute); //Any interrupts should be subscribed to the interrupt event - these actions occur now.
            blockToExecute.PostInterrupt();                         // Block performs rest of actions, post-interrupt.
        }


    }
}