using System.Security.Cryptography.X509Certificates;
using UnityEditor;

namespace Assets.Code.Scripts
{
    public interface IBlock
    {
        void PreInterrupt();
        void PostInterrupt();
    }
}