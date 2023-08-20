using SpawnerSystem.PoolManager.Controller;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.PoolManager.Enum;
using SpawnerSystem.PoolManager.Signals;
using UnityEngine;

namespace SpawnerSystem.PoolManager
{
    public class PoolManager : Root.SpawnerSystem
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PoolController poolController;

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
            PoolSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            PoolSignals.Instance.onListAdd -= OnListAdd;
            PoolSignals.Instance.onListRemove -= OnListRemove;
            PoolSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        public void OnListAdd(GameObject poolObj, PoolType poolType)
        {
            poolController.Listadd(poolObj,poolType);
        }

        public GameObject OnListRemove(PoolType poolType)
        {
           return poolController.ListRemove(poolType);
        }

        public void OnReset()
        {
            poolController.Reset();
        }
    }
}