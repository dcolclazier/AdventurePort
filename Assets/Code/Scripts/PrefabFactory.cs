using Assets.Code.GameObjects._Halo;
using Assets.Code.GameObjects._Path;
using Assets.Code.GameObjects._Player;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class PrefabFactory : MonoBehaviour
    {
        public static PrefabFactory Instance { get; private set; }

        public void Awake()
        {
            Instance = this;
        }

        public HaloPrefab CreateSelectorHalo(Player player)
        {
            var haloPrefab = (GameObject) Instantiate(Resources.Load("Prefabs/HaloPrefab"));
            var halo = haloPrefab.GetComponent<HaloPrefab>();
            halo.Initialize(player);
            return halo;
        }

        public PathCirclePrefab CreatePathTurnCircle(float radius)
        {
            var pathCircleObject = (GameObject) Instantiate(Resources.Load("Prefabs/Path/PathCirclePrefab"));
            var pathCirclePrefab = (PathCirclePrefab) pathCircleObject.GetComponent(typeof (PathCirclePrefab));
            pathCirclePrefab.Initialize(radius);
            return pathCirclePrefab;
        }

        public PathLinePrefab CreatePathLine()
        {
            var pathLineObj = (GameObject)Instantiate(Resources.Load("Prefabs/Path/PathLinePrefab"));
            var pathLinePrefab = (PathLinePrefab)pathLineObj.GetComponent(typeof(PathLinePrefab));
            return pathLinePrefab;
        }
    }
}