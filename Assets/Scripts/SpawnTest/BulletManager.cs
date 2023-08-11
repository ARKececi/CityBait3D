using System;
using SpawnerSystem.PoolManager.Controller.Interface;
using SpawnerSystem.SpawnManager.Signals;
using UnityEngine;

namespace SpawnTest
{
    public class BulletManager : MonoBehaviour, IPoolable
    {
        [SerializeField] private Rigidbody rigidbody;
        public GameObject IGameObject => transform.gameObject;
        public Transform ITransform => transform;
        public Rigidbody IRigidbody => rigidbody;
        
    }
}