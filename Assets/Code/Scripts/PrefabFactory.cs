using Assets.Code.GameObjects.Path;
using Assets.Code.GameObjects.Player;
using Assets.Code.GameObjects.SelectorHalo;
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

        public SelectorHaloPrefab CreateSelectorHalo(Player player)
        {
            var haloPrefab = (GameObject) Instantiate(Resources.Load("Prefabs/SelectorHaloPrefab"));
            var halo = haloPrefab.GetComponent<SelectorHaloPrefab>();
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
    }
}