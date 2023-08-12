using UnityEngine;
using WeaponsSystem.WeaponManager.Data.ValueObject;

namespace WeaponSystem.WeaponManager.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Weapons", menuName = "Data/CD_Weapons", order = 0)]
    public class CD_Weapons : ScriptableObject
    {
        public WeaponsData WeaponsData;
    }
}