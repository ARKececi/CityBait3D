using System;
using UnityEngine;

namespace WeaponsSystem.WeaponManager.Data
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