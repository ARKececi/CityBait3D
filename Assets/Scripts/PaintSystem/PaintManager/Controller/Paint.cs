using System;
using BulletSystem.BulletController;
using PaintIn3D;
using UnityEngine;
using UnityEngine.UIElements;

namespace SpawnTest
{
    public class Paint : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private P3dPaintDecal p3dPaintDecal;
        [SerializeField] private GameObject paintObj;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PaintSignals.Instance.onTransform += OnTransform;
            PaintSignals.Instance.onColor += OnColor;
            PaintSignals.Instance.onScale += OnScale;
            PaintSignals.Instance.onActive += OnActive;
        }

        private void UnsubscribeEvents()
        {
            PaintSignals.Instance.onTransform -= OnTransform;
            PaintSignals.Instance.onColor -= OnColor;
            PaintSignals.Instance.onScale -= OnScale;
            PaintSignals.Instance.onActive -= OnActive;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnTransform(Vector3 vec)
        {
            transform.position = vec;
        }

        private void OnColor(Color color)
        {
            p3dPaintDecal.Color = color;
        }

        private void OnScale(Vector3 vec)
        {
            p3dPaintDecal.Scale = vec;
        }

        public void OnActive(bool bol)
        {
            paintObj.SetActive(bol);
        }
    }
}