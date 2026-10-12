using UnityEngine.AI;

public class JumpController 
{
    private NavMeshAgent _agent;
    private AgentJumper _agentJumper;

    public JumpController (NavMeshAgent agent, AgentJumper agentJumper)
    {
        _agent = agent; 
        _agentJumper = agentJumper;
    }

    public void Update()
    {
        if (_agent.isOnOffMeshLink)
            _agentJumper.Jump(_agent.currentOffMeshLinkData);
    }
}
