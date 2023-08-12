using System;
using UnityEngine;
using WeaponSystem.WeaponManager.Enum;

namespace WeaponSystem.WeaponManager.Data
{
    [Serializable]
    public struct WeaponData
    {
        public float FlicTime;
        public float ReloadTime;
        public int Magazine;
        public GameObject Weapon;
    }
}