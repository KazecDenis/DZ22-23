using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour, IDamageable, IMovable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _rotationSpeed = 600f;
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private AnimationCurve _jumpYOffset;
    private Character _character;
    private NavMeshMovement _meshMovement;
    private NavMeshAgent _agent;
    private AgentJumper _agentJumper;
    private NavMeshRotator _meshRotator;
    
    private void Awake()
    {
        _character = new Character(_maxHealth);
        
        _agent = GetComponent<NavMeshAgent>();

        _meshMovement = new NavMeshMovement(_agent);

        DirectionRotate directionRotate = new DirectionRotate(transform, _rotationSpeed);
        _meshRotator = new NavMeshRotator(_agent, directionRotate);

        _agentJumper = new AgentJumper(_agent, this, _jumpSpeed, _jumpYOffset);

        _characterView.Initialize(_character, _agentJumper);
    }

    private void Update()
    {
        if (_character.Health.IsDead)
            return;

        _meshRotator.Update(Time.deltaTime);  

        if (_agent.isOnOffMeshLink)
            _agentJumper.Jump(_agent.currentOffMeshLinkData);
    }

    public void TakeDamage(int damage)
    {
        if (_character.Health.IsDead)
            return;

        _character.Health.TakeDamage(damage);
        _characterView.StartTakeDamageAnimation();
        Debug.Log(_character.Health.Current);

        if (_character.Health.IsDead)
        {
            Stop();
            _characterView.StartDeadAnimation();
        }
    }

    public void Move(Vector3 position)
    {
        if (_character.Health.IsDead)
            return;
            
        _meshMovement.TrySetDestination(position);
    }

    public void Stop()
    {
        _meshMovement.StopAgent();
    }

    public bool Heal(int healAmount)
    {
        if (_character.Health.Current >= _character.Health.Max)
            return false;

        _character.Health.AddHealth(healAmount);
        Debug.Log(_character.Health.Current);
        return true;
    }
        
}
        


   

        
