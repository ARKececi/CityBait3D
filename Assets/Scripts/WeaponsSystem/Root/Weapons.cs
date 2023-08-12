using UnityEngine;
using UnityEngine.Serialization;
using WeaponSystem;

namespace WeaponsSystem.Root
{
    public class Weapons : MonoBehaviour
    {
        [FormerlySerializedAs("WeaponID")] public WeaponsID weaponsID;
    }
}