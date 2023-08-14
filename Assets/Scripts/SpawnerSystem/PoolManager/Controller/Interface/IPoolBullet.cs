using UnityEngine;

namespace SpawnerSystem.PoolManager.Controller.Interface
{
    public interface IPoolBullet
    {
        public GameObject BulletObject { get; }
        public Transform Transform { get; }
        public Rigidbody IRigidbody { get; }
    }
}