using System;
using UnityEngine;
using UnityEngine.Serialization;
using WeaponsSystem.WeaponManager.Controller.Interface;
using WeaponsSystem.Weapons.WeaponRoot;

namespace WeaponsSystem.Weapons
{
    public class Pistol : Weapon,IWeapon
    {
        #region Self Variables

        #region Public Variables

        public float FlicTime { get; set; }
        public float ReloadTime { get; set; }
        public int Magazine { get; set; }
        public GameObject WeaponPrefabs => gameObject;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject BarrelObject;

        #endregion

        #region Private Variables

        private float _fireTimer;
        private float _reloadTimer;
        private float _magazine;

        #endregion

        #endregion

        private void Start()
        {
            _magazine = Magazine;
            _reloadTimer = ReloadTime;
            barrel = BarrelObject;
        }

        private void FixedUpdate()
        {
            FireTimer();
        }

        private void FireTimer()
        {
            if (_magazine > 0)
            {
                while(_fireTimer < 0)
                {
                    Fire();
                    _magazine--;
                    _fireTimer = FlicTime;
                } 
                _fireTimer -= Time.deltaTime;
            }
            else
            {
                while (_reloadTimer < 0)
                {
                    _magazine = Magazine;
                    _reloadTimer = ReloadTime;
                }

                _reloadTimer -= Time.deltaTime;
            }
        }
    }
}