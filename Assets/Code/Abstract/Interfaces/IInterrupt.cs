namespace Assets.Code.Abstract.Interfaces
{
    public interface IInterrupt
    {
        bool Active { get; }
        void InterruptAction(IBlock stackBlock);
    }
}