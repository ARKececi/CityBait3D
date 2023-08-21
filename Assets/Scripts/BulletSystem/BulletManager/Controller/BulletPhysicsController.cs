using System;
using Ahmet;
using BoundarySystem.BoundaryManager.Controller;
using DG.Tweening;
using PaintIn3D;
using SpawnerSystem.PoolManager.Enum;
using SpawnerSystem.PoolManager.Signals;
using UnityEngine;

namespace BulletSystem.BulletController
{
    public class BulletPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BulletManager.Controller.BulletController bulletController;

        #endregion
        
        #endregion

        private void OnTriggerEnter(Collider hit)
        {
            if (hit.TryGetComponent(out Npc npc))
            {
                bulletController.NpcTrigger(npc);
            }
            else if (hit.TryGetComponent(out P3dPaintable paintable))
            {
                Debug.Log("Paintable");
                bulletController.PlaneTrigger();
            }
        }

        private void OnTriggerExit(Collider hit)
        {
            if (hit.TryGetComponent(out BoundaryPhysicsController boundary))
            {
                PoolSignals.Instance.onListAdd?.Invoke(bulletController.gameObject,PoolType.BulletLow);
            }
        }
        
        
    }
}