using UnityEngine;

namespace WeaponsSystem.Root
{
    [CreateAssetMenu(fileName = "WeaponID", menuName = "IDMenu/WeaponID", order = 0)]
    public class WeaponsID : ScriptableObject
    {
        public WeaponsLocalSignals WeaponsLocalSignals;
    }
}