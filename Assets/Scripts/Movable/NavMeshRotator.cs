using UnityEngine;
using UnityEngine.AI;

public class NavMeshRotator
{
   private NavMeshAgent _agent;
   private DirectionRotate _rotate;

   public NavMeshRotator(NavMeshAgent agent, DirectionRotate rotate)
    {
        _agent = agent;
        _rotate = rotate;
    }

    public void Update(float deltaTime)
    {
        Vector3 direction = _agent.steeringTarget - _agent.transform.position;

        _rotate.SetInputDirection(direction);
        _rotate.Update(deltaTime);
    }
}
