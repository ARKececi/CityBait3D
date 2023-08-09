using UnityEngine;

namespace SpawnerSystem.Root
{
    [CreateAssetMenu(fileName = "SpawnerID", menuName = "IDMenu/SpawnerID", order = 0)]
    public class SpawnerID : ScriptableObject
    {
        public SpawnerLocalSignals SpawnerLocalSignals;
    }
}