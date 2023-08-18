using PaintSystem.PaintManager.Data.ValueData;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace PaintSystem.PaintManager.Data.UnityData
{
    [CreateAssetMenu(fileName = "CD_Paint", menuName = "Data/CD_Paint", order = 0)]
    public class CD_Paint : ScriptableObject
    {
        public SerializedDictionary<PaintType,PaintData> PaintDatas;
    }
}