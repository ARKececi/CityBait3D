using Extentions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace SpawnTest
{
    public class PaintSignals : MonoSingleton<PaintSignals>
    {
        public UnityAction<Vector3> onTransform= delegate { };
        public UnityAction<Color> onColor = delegate { };
        public UnityAction<Vector3> onScale = delegate { };
        public UnityAction<bool> onActive = delegate { };
    }
}