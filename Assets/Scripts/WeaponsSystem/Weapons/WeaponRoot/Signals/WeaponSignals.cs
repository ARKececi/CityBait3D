using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponsSystem.Weapons.WeaponRoot.Signals
{
    public class WeaponSignals : MonoSingleton<WeaponSignals>
    {
        public Func<GameObject> onBarrel = delegate { return null; };
        public UnityAction<Vector3> onAimPosition = delegate { };
        public Func<Vector3> onAimPositionReturn = delegate { return Vector3.zero;};
        public UnityAction onMagazineAmount = delegate { };
    }
}