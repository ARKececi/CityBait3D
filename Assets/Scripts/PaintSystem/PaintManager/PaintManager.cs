using PaintSystem.PaintManager.Data.UnityData;
using PaintSystem.PaintManager.Data.ValueData;
using PaintSystem.PaintManager.Signals;
using SpawnTest;
using UnityEngine;
using UnityEngine.Rendering;

namespace PaintSystem.PaintManager
{
    public class PaintManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PaintController paintController;

        #endregion

        #region Private Variables

        private readonly string PAINT_DATA = "Data/CD_Paint";

        #endregion

        #endregion
        
        private void Awake()
        {
            paintController.paintData = GetPaintData();
        }

        private SerializedDictionary<PaintType, PaintData> GetPaintData()
        {
            return Resources.Load<CD_Paint>(PAINT_DATA).PaintDatas;
        }
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PaintSignals.Instance.onPaintNpc += OnPaintNpc;
            PaintSignals.Instance.onPaintPlane += OnPaintPlane;
        }

        private void UnsubscribeEvents()
        {
            PaintSignals.Instance.onPaintNpc -= OnPaintNpc;
            PaintSignals.Instance.onPaintPlane -= OnPaintPlane;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnPaintNpc(Color color, Vector3 position)
        {
            paintController.PaintNpc(color,position);
        }

        private void OnPaintPlane(Vector3 position)
        {
            paintController.PaintPlane(position);
        }
    }
}