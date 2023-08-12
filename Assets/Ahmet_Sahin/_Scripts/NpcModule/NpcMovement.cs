using System;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

namespace Ahmet
{
    public class NpcMovement : NpcSystem
    {
        private NavMeshAgent _agent;
        [SerializeField] private float _range;
        [SerializeField] private float _rotationSpeed;

        private readonly float _minRemainingDistance = 0.5f;
        private readonly float _minVelocityMagnitude = 0.1f;
 

        protected override void Awake()
        {
            base.Awake();
            _agent = transform.root.GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }


        private void Update()
        {
            RandomDestinationUpdater();
            SetRotation();
        }

        public Vector3 RandomPoint()
        {
            Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * _range;
            NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, _range, 1);
            return hit.position;
        }

        private void RandomDestinationUpdater()
        {
            if (_agent.remainingDistance < _minRemainingDistance)
            {
                _agent.SetDestination(RandomPoint());
            }
        }

        private void SetRotation()
        {
            if (_agent.velocity.magnitude > _minVelocityMagnitude)
            {
                Quaternion lookRotation = Quaternion.LookRotation(_agent.velocity);
                npc.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
            }
        }

        private void AddListeners()
        {

        }

        private void RemoveListeners()
        {

        }

    }
}