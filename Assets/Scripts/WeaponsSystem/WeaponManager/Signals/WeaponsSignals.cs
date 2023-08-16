using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponsSystem.WeaponManager.Signals
{
    public class WeaponsSignals : MonoSingleton<WeaponsSignals>
    {
        public UnityAction onWeaponLevelUp = delegate { };
    }
}