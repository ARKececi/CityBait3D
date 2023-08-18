using System;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;
using WeaponsSystem.Weapons.WeaponRoot.Signals;

namespace WeaponsSystem.Weapons.WeaponRoot
{
    public class BaseWeapon : MonoBehaviour
    {
        #region Self Variables

        #region Protected Variables

        protected GameObject barrel;
        protected int magazine;

        protected float flicTime;

        protected float reloadTime;

        #endregion

        #region Private Variables
        
            private Vector3 _aimPosition;
            private float _fireTimerBase;
            private float _reloadTimerBase;
            private float _magazineBase;

        #endregion

        #endregion

        private void Start()
        {
            _magazineBase = magazine;
            _reloadTimerBase = reloadTime;
        }

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

        protected void FireTimer()
        {
            if (_magazineBase > 0)
            {
                while(_fireTimerBase < 0)
                {
                    Fire();
                    _magazineBase--;
                    _fireTimerBase = flicTime;
                } 
                _fireTimerBase -= Time.deltaTime;
            }
            else
            {
                while (_reloadTimerBase < 0)
                {
                    _magazineBase = magazine;
                    _reloadTimerBase = reloadTime;
                }

                _reloadTimerBase -= Time.deltaTime;
            }
        }
        
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