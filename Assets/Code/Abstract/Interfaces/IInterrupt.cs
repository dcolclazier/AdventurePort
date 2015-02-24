using Assets.Code.Scripts;

namespace Assets.Code.GameStack.Interrupts
{
    public interface IInterrupt
    {
        bool Active { get; }
        void InterruptAction(IBlock stackBlock);
    }
}