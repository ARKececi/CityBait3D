using System;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace SpawnTest
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        [SerializeField] private Rigidbody rigidbody;
        public GameObject BulletObject => transform.gameObject;
        public Transform Transform => transform;
        public Rigidbody IRigidbody => rigidbody;
    }
}