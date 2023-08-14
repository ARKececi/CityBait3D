using System;
using PaintIn3D;
using UnityEngine;

namespace SpawnTest
{
    public class PaintPhysics : MonoBehaviour
    {
        #region Slef Variables

        #region Serialized Variables

        [SerializeField] private Paint paint;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out P3dPaintable plane))
            {
                paint.OnActive(false);
            }
        }
    }
}