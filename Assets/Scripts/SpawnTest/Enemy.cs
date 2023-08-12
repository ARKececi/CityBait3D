using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;

namespace SpawnTest
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        [SerializeField] private Rigidbody rigidbody;
        public GameObject BulletObject => transform.gameObject;
        public Transform Transform => transform;
        public Rigidbody IRigidbody => rigidbody;
    }
}