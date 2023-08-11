using SpawnerSystem.PoolManager.Controller.Interface;
using UnityEngine;

namespace SpawnTest
{
    public class EnemyManager : MonoBehaviour, IPoolable
    {
        [SerializeField] private Rigidbody rigidbody;
        public GameObject IGameObject => transform.gameObject;
        public Transform ITransform => transform;
        public Rigidbody IRigidbody => rigidbody;
    }
}