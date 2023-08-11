using System;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace SpawnTest
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private GameObject barrel;
        [SerializeField] private float fireTime;

        private void Start()
        {
            SpawnSignals.Instance.onWeaponProperty?.Invoke(fireTime,barrel);
        }
    }
}