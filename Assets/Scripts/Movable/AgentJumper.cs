using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumper
{
   private float _jumpSpeed;
   private AnimationCurve _jumpYOffset;
   private NavMeshAgent _agent;
   private Coroutine _jumpProcess;
   private MonoBehaviour _coroutineRunner;
   public bool InProcess => _jumpProcess != null;

    public AgentJumper (NavMeshAgent agent, MonoBehaviour coroutineRunner, float jumpSpeed, AnimationCurve jumpYOffset)
    {
        _agent = agent;
        _coroutineRunner = coroutineRunner;
        _jumpSpeed = jumpSpeed;
        _jumpYOffset = jumpYOffset;
    }

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if(InProcess)
            return;

        _jumpProcess = _coroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData));
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPos = offMeshLinkData.startPos;
        Vector3 endPos = offMeshLinkData.endPos;

        float duration = Vector3.Distance(startPos, endPos) / _jumpSpeed;
        float process = 0;
        _agent.isStopped = true;
        _agent.updatePosition = false;

        while(process < duration)
        {
            float YOffset = _jumpYOffset.Evaluate(process / duration);
            float progress = process / duration;
            
            _agent.transform.position = Vector3.Lerp(startPos, endPos, progress) + Vector3.up * YOffset;
            process += Time.deltaTime;

            yield return null;
        }

        _agent.transform.position = endPos;
        _agent.updatePosition = true;
        _agent.isStopped = false;
        _agent.CompleteOffMeshLink();
        _jumpProcess = null;
    }
}
