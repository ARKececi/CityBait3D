using UnityEngine;

namespace WeaponsSystem.WeaponManager.Controller.Interface
{
    public interface IWeapon
    {
        public float FlicTime { get; set; }
        public float ReloadTime { get; set; }
        public int Magazine { set; }
        public GameObject WeaponPrefabs { get; }
    }
}