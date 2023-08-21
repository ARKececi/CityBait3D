using UnityEngine;
using UnityEngine.Serialization;
using WeaponsSystem.WeaponManager.Controller.Interface;
using WeaponsSystem.Weapons.WeaponRoot;

namespace WeaponsSystem.Weapons
{
    public class Smg : BaseWeapon,IWeapon
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

        #endregion

        private void Start()
        {
            barrel = BarrelObject;
            magazine = GetActiveMagazine();
            flicTime = FlicTime;
            reloadTime = ReloadTime;
        }
        
        private int GetActiveMagazine()
        {
            if (!ES3.FileExists()) return Magazine;
            return ES3.KeyExists("Magazine") ? ES3.Load<int>("Magazine") : Magazine;
        }
    }
}