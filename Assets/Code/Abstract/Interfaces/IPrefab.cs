using Assets.Code.GameObjects._Player;

namespace Assets.Code.Abstract.Interfaces
{
    public interface IPrefab
    {
        bool Enabled { set; }
        void Destroy();
    }
}