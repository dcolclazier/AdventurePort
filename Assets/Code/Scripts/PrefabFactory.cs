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

        public SelectorHalo CreateSelectorHalo(Player player)
        {
            var haloPrefab = (GameObject) Instantiate(Resources.Load("Prefabs/SelectorHaloPrefab"));
            var halo = haloPrefab.GetComponent<SelectorHalo>();
            halo.Initialize(player);
            return halo;
        }
        
        public PathPrefab CreatePathPrefab()
        {
            var pathPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/PathPrefab"));
            return (PathPrefab) pathPrefab.GetComponent(typeof (PathPrefab));
        
        }
    }
}