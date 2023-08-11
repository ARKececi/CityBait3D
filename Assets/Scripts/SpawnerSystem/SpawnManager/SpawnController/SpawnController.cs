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
        [SerializeField] private float fireTime;
        [SerializeField] private GameObject barrel;
        [SerializeField] private int force;
        private const float spawnRadius = 5;
        [SerializeField] private GameObject enemySpawnDot;

        #endregion

        #region Private Variables

        private float _enemyTime;
        private int _enemyStackCount;
        private float _fireTimer;
        
        #endregion

        #endregion
        
        #region LocalEvent Subscription
        private void OnEnable()
        {
            spawner.SpawnerID.SpawnerLocalSignals.weaponProperty += WeaponProperty;
        }
        private void OnDisable()
        {
            spawner.SpawnerID.SpawnerLocalSignals.weaponProperty -= WeaponProperty;
        }
        #endregion
        
        private void FixedUpdate()
        {
            FireTimer();
            EnemyTimer();
        }

        public void WeaponProperty(float time, GameObject weaponBarrel)
        {
            fireTime = time;
            barrel = weaponBarrel;
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
            IPoolable enemy = spawner.SpawnerID.SpawnerLocalSignals.onListRemove?.Invoke(PoolType.EnemyLow);
            float enemyPositionX = Random.Range(-spawnRadius, spawnRadius);
            float enemySpawnDotZ = Random.Range(-spawnRadius, spawnRadius);
            var position = enemySpawnDot.transform.position;
            if (enemy != null) enemy.ITransform.position = new Vector3(enemyPositionX, position.y, enemySpawnDotZ);
        }
        
        private void FireTimer()
        {
            while(_fireTimer < 0)
            {
                BulletSpawner();
                _fireTimer = fireTime;
            } 
            _fireTimer -= Time.deltaTime;
        }
        
        private void BulletSpawner()
        {
            IPoolable bullet = spawner.SpawnerID.SpawnerLocalSignals.onListRemove?.Invoke(PoolType.BulletLow);
            bullet.ITransform.position = barrel.transform.position;
            bullet?.IRigidbody.AddForce(barrel.transform.forward * force, ForceMode.Impulse);
        }
    }
}