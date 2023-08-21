using Ahmet;
using PaintIn3D;
using PaintSystem.PaintManager.Signals;
using SpawnerSystem.PoolManager.Enum;
using SpawnerSystem.PoolManager.Signals;
using SpawnTest;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace BulletSystem.BulletManager.Controller
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
            PaintSignals.Instance.onPaintNpc?.Invoke(npc.Color, npc.transform.position);
            PoolSignals.Instance.onListAdd?.Invoke(npc.gameObject,PoolType.EnemyLow);
            NpcSignals.Instance.onNpcHit?.Invoke();
            SetPool();
        }

        public void PlaneTrigger()
        {
            PaintSignals.Instance.onPaintPlane?.Invoke(_aimPosition);
            SetPool();
        }

        public void SetPool()
        {
            PoolSignals.Instance.onListAdd?.Invoke(gameObject,PoolType.BulletLow);
        }
    }
}