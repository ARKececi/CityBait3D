using System;
using Ahmet;
using PaintIn3D;
using SpawnerSystem.PoolManager.Enum;
using SpawnerSystem.PoolManager.Signals;
using SpawnTest;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace BulletSystem.BulletController
{
    public class BulletController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private Rigidbody rigidbody;

        #endregion

        #region Private Variables

        private const int force = 30;
        private P3dPaintDecal _p3dPaintDecal;
        private Vector3 _aimPosition;

        #endregion

        #endregion

        private void OnEnable()
        {
            GameObject barrel = WeaponSignals.Instance.onBarrel?.Invoke();
            if (barrel != null) rigidbody.AddForce(barrel.transform.forward * force, ForceMode.Impulse);
            _aimPosition = (Vector3)WeaponSignals.Instance.onAimPositionReturn?.Invoke();
        }

        private void OnDisable()
        {
            rigidbody.velocity = Vector3.zero;
        }

        public void NpcTrigger(Npc npc)
        {
            PaintSignals.Instance.onScale?.Invoke(new Vector3(3f, 3f, 3f));
            PaintSignals.Instance.onColor?.Invoke(npc.Color); 
            PaintSignals.Instance.onTransform?.Invoke(npc.transform.position);
            PaintSignals.Instance.onActive?.Invoke(true);
            PoolSignals.Instance.onListAdd?.Invoke(npc.gameObject,PoolType.EnemyLow);
            SetPool();
        }

        public void PlaneTrigger()
        {
            PaintSignals.Instance.onScale?.Invoke(new Vector3(1f, 1f, 1f));
            PaintSignals.Instance.onTransform?.Invoke(_aimPosition);
            PaintSignals.Instance.onActive?.Invoke(true);
            SetPool();
        }

        public void SetPool()
        {
            PoolSignals.Instance.onListAdd?.Invoke(gameObject,PoolType.BulletLow);
        }
    }
}