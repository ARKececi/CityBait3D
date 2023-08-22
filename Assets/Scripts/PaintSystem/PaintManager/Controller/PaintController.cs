using PaintIn3D;
using PaintSystem.PaintManager;
using PaintSystem.PaintManager.Data.ValueData;
using SaveSystem.SaveManager.Signals;
using UnityEngine;
using UnityEngine.Rendering;

namespace SpawnTest
{
    public class PaintController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<PaintType, PaintData> paintData;

        #endregion

        #region Serialized Variables
        
        [SerializeField]
        private P3dPaintDecal p3dPaintDecal;
        [SerializeField] 
        private GameObject paintObj;

        #endregion

        #endregion

        public void OnActive(bool bol)
        {
            paintObj.SetActive(bol);
        }

        public void PaintNpc(Color color, Vector3 position)
        {
            p3dPaintDecal.Scale = paintData[PaintType.Npc].PaintScale;
            p3dPaintDecal.Color = color;
            transform.position = position;
            OnActive(true);
        }

        public void PaintPlane(Vector3 position)
        {
            p3dPaintDecal.Scale = paintData[PaintType.Plane].PaintScale;
            transform.position = position;
            OnActive(true);
        }

        public void MapSave(GameObject map)
        {
            SaveSignals.Instance.onMapSave?.Invoke(map.transform.parent.gameObject);
        }
    }
}