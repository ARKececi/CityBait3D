using System;
using UnityEngine;
using UnityEngine.AI;



public class NpcMovement : NpcSystem
{
    private NavMeshAgent _agent;
    [SerializeField] private float _range;
    [SerializeField] private float _rotationSpeed;
    

    protected override void Awake()
    {
        base.Awake();
        _agent = transform.root.GetComponent<NavMeshAgent>();
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
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }

    private void RandomDestinationUpdater()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            _agent.SetDestination(RandomPoint());
        }
    }

    private void SetRotation()
    {
        if (_agent.velocity.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(_agent.velocity);
            npc.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}



