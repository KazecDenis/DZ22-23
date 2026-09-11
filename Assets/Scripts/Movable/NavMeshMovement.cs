using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement
{
   private NavMeshAgent _agent;
   private float _maxDistance = 2f;

   public NavMeshMovement(NavMeshAgent navMeshAgent)
    {
        _agent = navMeshAgent;
    }

    public bool TrySetDestination(Vector3 position)
    {
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, _maxDistance, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
            return true;
        }

        return false;
    }
}
