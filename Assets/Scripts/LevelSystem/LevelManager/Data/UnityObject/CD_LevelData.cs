using UnityEngine;
using UnityEngine.Serialization;

namespace LevelSystem.LevelManager.Data
{
    [CreateAssetMenu(fileName = "CD_LevelData", menuName = "Data/CD_LevelData", order = 0)]
    public class CD_LevelData : ScriptableObject
    {
        public int LevelCount;
    }
}