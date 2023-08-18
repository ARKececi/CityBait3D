using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace PaintSystem.PaintManager.Signals
{
    public class PaintSignals : MonoSingleton<PaintSignals>
    {
        public UnityAction<Color,Vector3> onPaintNpc = delegate { };
        public UnityAction<Vector3> onPaintPlane = delegate { };
    }
}