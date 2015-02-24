namespace Assets.Code.States
{
    public interface IPrefab
    {
        void Initialize(Player player);
        void Destroy();
    }
}