using SpawnerSystem.PoolManager.Data.ValueObject;
using SpawnerSystem.PoolManager.Enum;
using UnityEngine;
using UnityEngine.Rendering;

namespace SpawnerSystem.PoolManager.Controller.Interface
{
    public interface IPoolable
    {
        public GameObject BulletObject { get; }
        public Transform Transform { get; }
        public Rigidbody IRigidbody { get; }
    }
}