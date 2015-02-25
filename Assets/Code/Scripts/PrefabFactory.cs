using Assets.Code.GameObjects._Halo;
using Assets.Code.GameObjects._Path;
using Assets.Code.GameObjects._Player;
using UnityEngine;

namespace Assets.Code.Scripts
{
    public class PrefabFactory : MonoBehaviour
    {
        public static PrefabFactory Instance { get; private set; }

        public GameObject PathPrefab;
        public GameObject SelectorHaloPrefab;

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
        
        public PathPrefab CreatePathPrefab(Player player)
        {
            var pathObject = (GameObject)Instantiate(Resources.Load("Prefabs/PathPrefab"));
            var pathPrefab = (PathPrefab) pathObject.GetComponent(typeof (PathPrefab));
            pathPrefab.Initialize(player);
            return pathPrefab;
        }

        public TurnCirclePrefab CreatePathTurnCircle(float radius)
        {
            var turnCircleObject = (GameObject) Instantiate(Resources.Load("Prefabs/Path/TurnCirclePrefab"));
            var turnCirclePrefab = (TurnCirclePrefab) turnCircleObject.GetComponent(typeof (TurnCirclePrefab));
            turnCirclePrefab.Initialize(radius);
            return turnCirclePrefab;
        }

        public PathLinePrefab CreatePathLine()
        {
            var pathLineObj = (GameObject)Instantiate(Resources.Load("Prefabs/Path/PathLinePrefab"));
            var pathLinePrefab = (PathLinePrefab)pathLineObj.GetComponent(typeof(PathLinePrefab));
            return pathLinePrefab;
        }
    }
}