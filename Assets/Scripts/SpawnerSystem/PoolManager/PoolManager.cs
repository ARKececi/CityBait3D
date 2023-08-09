using SpawnerSystem.PoolManager.Controller;
using SpawnerSystem.PoolManager.Enum;
using SpawnerSystem.PoolManager.Signals;
using UnityEngine;

namespace SpawnerSystem.PoolManager
{
    public class PoolManager : Root.SpawnerSystem
    {
        #region Self Variables

        #region Serialized Variables

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PoolSignals.Instance.onListAdd += OnListAdd;
            PoolSignals.Instance.onListRemove += OnListRemove;
        }

        private void UnsubscribeEvents()
        {
            PoolSignals.Instance.onListAdd -= OnListAdd;
            PoolSignals.Instance.onListRemove -= OnListRemove;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        public void OnListAdd(GameObject poolObj, PoolType poolType)
        {
            spawner.SpawnerID.SpawnerLocalSignals.onListAdd?.Invoke(poolObj,poolType);
        }

        public GameObject OnListRemove(PoolType poolType)
        {
            return spawner.SpawnerID.SpawnerLocalSignals.onListRemove?.Invoke(poolType);
        }
    }
}