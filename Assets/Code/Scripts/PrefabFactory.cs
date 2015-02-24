using UnityEngine;

namespace Assets.Code.Scripts
{
    public class PrefabFactory : MonoBehaviour
    {
        public static PrefabFactory Instance { get; private set; }

        public GameObject PathPrefab;

        public void Awake()
        {
            Instance = this;
        }
        
        public PathPrefab CreatePathPrefab(Player player)
        {
            //if (player.Path != null) return player.Path.PathPrefab;

            var pathPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/PathPrefab"));
            return (PathPrefab) pathPrefab.GetComponent(typeof (PathPrefab));
        
        }
    }
}