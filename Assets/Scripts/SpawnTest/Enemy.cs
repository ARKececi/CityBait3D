using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;

namespace SpawnTest
{
    public class Enemy : MonoBehaviour, IPoolableEnemy
    {
        public GameObject BulletObject => transform.gameObject;
        public Transform Transform => transform;
    }
}