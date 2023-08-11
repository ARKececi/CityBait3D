using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace SpawnerSystem.SpawnManager
{
    public class SpawnManager : Root.SpawnerSystem
    {
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SpawnSignals.Instance.onWeaponProperty += OnWeaponProperty;
        }

        private void UnsubscribeEvents()
        {
            SpawnSignals.Instance.onWeaponProperty -= OnWeaponProperty;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnWeaponProperty(float time, GameObject barrel)
        {
            spawner.SpawnerID.SpawnerLocalSignals.weaponProperty?.Invoke(time,barrel);
        }
    }
}