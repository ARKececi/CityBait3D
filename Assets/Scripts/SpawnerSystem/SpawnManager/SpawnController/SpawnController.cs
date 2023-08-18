using System;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace SpawnerSystem.SpawnManager.SpawnController
{
    public class SpawnController : Root.SpawnerSystem
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private float enemyTime;
        [SerializeField] private int enemyCount;
        private const float spawnRadius = 5;
        [SerializeField] private GameObject enemySpawnDot;

        #endregion

        #region Private Variables

        private float _enemyTime;
        private int _enemyStackCount;

        #endregion

        #endregion

        public void EnemyCountReduction(){_enemyStackCount--;}
        public void EnemyCountIncrease(){enemyCount++;}
        
        private void FixedUpdate()
        {
            EnemyTimer();
        }

        private void EnemyTimer()
        {
            if (_enemyStackCount < enemyCount)
            {
                while(_enemyTime < 0)
                {
                    EnemySpawner();
                    _enemyStackCount++;
                    _enemyTime = enemyTime;
                } 
                _enemyTime -= Time.deltaTime;
            }
        }
        
        private void EnemySpawner()
        {
            GameObject enemy = spawner.SpawnerID.SpawnerLocalSignals.onListRemove?.Invoke(PoolType.EnemyLow);
            float enemyPositionX = Random.Range(-spawnRadius, spawnRadius);
            float enemySpawnDotZ = Random.Range(-spawnRadius, spawnRadius);
            var position = enemySpawnDot.transform.position;
            if (enemy != null) enemy.transform.position = new Vector3(enemyPositionX, position.y, enemySpawnDotZ);
        }

        public GameObject BulletSpawner()
        {
            GameObject bullet = spawner.SpawnerID.SpawnerLocalSignals.onListRemove?.Invoke(PoolType.BulletLow);
            return bullet;
        }
    }
}