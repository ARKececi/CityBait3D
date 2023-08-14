using System;
using SpawnTest;
using UnityEngine;
using UnityEngine.Rendering;
using WeaponsSystem.WeaponManager.Controller.Interface;
using WeaponsSystem.WeaponManager.Data;
using WeaponsSystem.Weapons.WeaponRoot;
using WeaponSystem.WeaponManager.Data;
using WeaponSystem.WeaponManager.Data.UnityObject;
using WeaponSystem.WeaponManager.Enum;

namespace WeaponsSystem.WeaponManager.Controller
{
    public class WeaponsController : WeaponsSystem.Root.WeaponsSystem
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField]
        private SerializedDictionary<WeaponLevel, WeaponData> weaponData = new SerializedDictionary<WeaponLevel, WeaponData>();
        [SerializeField] 
        private SerializedDictionary<WeaponLevel, IWeapon> weaponsObj = new SerializedDictionary<WeaponLevel, IWeapon>();
        [SerializeField]
        private GameObject player;

        #endregion

        #region Private Variables

        private readonly string WEAPON_DATA = "Data/CD_Weapons";
        private WeaponLevel _weaponLevel = new WeaponLevel();

        #endregion

        #endregion

        private void Awake()
        {
            weaponData = GetWeaponData();
            WeaponInstantiate();
        }

        private SerializedDictionary<WeaponLevel, WeaponData> GetWeaponData()
        {
            return Resources.Load<CD_Weapons>(WEAPON_DATA).WeaponsData.WeaponData;
        }

        public void WeaponInstantiate()
        {
            foreach (var VARIABLE in weaponData.Keys)
            {
                IWeapon weapon = Instantiate(weaponData[VARIABLE].Weapon).GetComponent<IWeapon>();
                weapon.Magazine = weaponData[VARIABLE].Magazine;
                weapon.FlicTime = weaponData[VARIABLE].FlicTime;
                weapon.ReloadTime = weaponData[VARIABLE].ReloadTime;
                weaponsObj.Add(VARIABLE, weapon);
                weapon.WeaponPrefabs.transform.SetParent(player.transform);
                weapon.WeaponPrefabs.transform.localPosition = Vector3.zero;
                weapon.WeaponPrefabs.SetActive(false);
            }
        }

        public void WeaponLevelUp()
        {
            weaponsObj[_weaponLevel].WeaponPrefabs.SetActive(false);
            _weaponLevel.Level++;
            weaponsObj[_weaponLevel].WeaponPrefabs.SetActive(true);
        }
    }
}