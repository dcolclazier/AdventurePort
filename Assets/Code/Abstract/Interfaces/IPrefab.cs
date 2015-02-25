using Assets.Code.GameObjects._Player;

namespace Assets.Code.Abstract.Interfaces
{
    public interface IPrefab
    {
        void Initialize(Player player);
        void Destroy();
    }
}