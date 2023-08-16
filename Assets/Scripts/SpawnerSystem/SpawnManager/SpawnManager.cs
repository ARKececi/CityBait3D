using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace SpawnerSystem.SpawnManager
{
    public class SpawnManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private SpawnController.SpawnController spawnController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SpawnSignals.Instance.onBulletSpawner += OnBulletSpawner;
            SpawnSignals.Instance.onEnemyCountReduction += OnEnemyCountReduction;
        }

        private void UnsubscribeEvents()
        {
            SpawnSignals.Instance.onBulletSpawner -= OnBulletSpawner;
            SpawnSignals.Instance.onEnemyCountReduction -= OnEnemyCountReduction;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private GameObject OnBulletSpawner()
        {
           return spawnController.BulletSpawner();
        }

        private void OnEnemyCountReduction()
        {
            spawnController.EnemyCountReduction();
        }
    }
}