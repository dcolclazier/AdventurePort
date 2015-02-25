using Assets.Code.GameObjects.PlayerCharacter;

namespace Assets.Code.Abstract.Interfaces
{
    public interface IPrefab
    {
        void Initialize(Player player);
        void Destroy();
    }
}