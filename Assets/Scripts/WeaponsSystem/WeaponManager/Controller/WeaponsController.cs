using System;
using SaveSystem.SaveManager.Enum;
using SaveSystem.SaveManager.Signals;
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
    public class WeaponsController : Root.WeaponsSystem
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField]
        private SerializedDictionary<int, WeaponData> weaponData = new SerializedDictionary<int, WeaponData>();
        [SerializeField] 
        private SerializedDictionary<int, IWeapon> weaponsObj = new SerializedDictionary<int, IWeapon>();
        [SerializeField]
        private GameObject player;

        #endregion

        #region Private Variables

        private readonly string WEAPON_DATA = "Data/CD_Weapons";
        private int _weaponLevel;

        #endregion

        #endregion

        private void Awake()
        {
            weaponData = GetWeaponData();
            WeaponInstantiate();
            weaponsObj[GetActiveWeapon()].WeaponPrefabs.SetActive(true);
        }
        
        private int GetActiveWeapon()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("WeaponCount") ? ES3.Load<int>("WeaponCount") : 0;
        }

        private SerializedDictionary<int, WeaponData> GetWeaponData()
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
            int weaponlevel = _weaponLevel + 1;
            if (weaponsObj.TryGetValue(weaponlevel, out var value))
            {
                weaponsObj[_weaponLevel].WeaponPrefabs.SetActive(false);
                _weaponLevel++;
                SaveSignals.Instance.onSave?.Invoke(SaveType.FireRate, _weaponLevel);
                value.WeaponPrefabs.SetActive(true);
            }
        }
    }
}