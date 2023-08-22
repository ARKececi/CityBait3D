using System;
using PaintIn3D;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpawnTest
{
    public class PaintPhysics : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PaintController paintController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out P3dPaintable plane))
            {
                paintController.OnActive(false);
                //paintController.MapSave(plane.gameObject);
            }
        }
    }
}