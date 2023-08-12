using System;
using UnityEngine.Rendering;
using WeaponSystem.WeaponManager.Data;
using WeaponSystem.WeaponManager.Enum;

namespace WeaponsSystem.WeaponManager.Data.ValueObject
{
    [Serializable]
    public struct WeaponsData
    {
        public SerializedDictionary<WeaponLevel, WeaponData> WeaponData;
    }
}