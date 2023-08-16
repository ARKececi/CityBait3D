using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace WeaponsSystem.Weapons.WeaponRoot
{
    public class BaseWeapon : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public GameObject Barrel;

        #endregion

        #region Protected Variables
        protected GameObject barrel { get; set; }

        #endregion

        #region Private Variables
        
            private Vector3 _aimPosition;

        #endregion

        #endregion
        

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            WeaponSignals.Instance.onBarrel += OnBarrel;
            WeaponSignals.Instance.onAimPosition += OnAimPosition;
            WeaponSignals.Instance.onAimPositionReturn += OnAimPositionReturn;
        }

        private void UnsubscribeEvents()
        {
            WeaponSignals.Instance.onBarrel -= OnBarrel;
            WeaponSignals.Instance.onAimPosition -= OnAimPosition;
            WeaponSignals.Instance.onAimPositionReturn -= OnAimPositionReturn;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
        
        protected void Fire()
        {
            GameObject bullet = SpawnSignals.Instance.onBulletSpawner?.Invoke();
            bullet.transform.position = barrel.transform.position;
        }

        private GameObject OnBarrel()
        {
            return barrel;
        }

        private void OnAimPosition(Vector3 vec)
        {
            _aimPosition = vec;
            transform.LookAt(_aimPosition);
        }

        private Vector3 OnAimPositionReturn()
        {
            return _aimPosition;
        }
    }
}