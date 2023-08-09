using SpawnerSystem.PoolManager.Data.ValueObject;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Rendering;

namespace SpawnerSystem.PoolManager.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Pool", menuName = "Data/CD_Pool", order = 0)]
    public class CD_Pool : ScriptableObject
    {
        public SerializedDictionary<PoolType, PoolData> PoolDatas;
    }
}