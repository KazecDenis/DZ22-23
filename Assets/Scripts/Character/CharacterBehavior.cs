using UnityEngine;
using UnityEngine.AI;

public class CharacterBehavior : MonoBehaviour, IDamageable, IMovable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _rotationSpeed = 600f;
    [SerializeField] private CharacterView _characterView;
    private Character _character;
    private NavMeshMovement _meshMovement;
    private NavMeshRotator _meshRotator;
    
    private void Awake()
    {
        _character = new Character(_maxHealth);
        _characterView.Initialize(_character);
        
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        _meshMovement = new NavMeshMovement(agent);

        DirectionRotate directionRotate = new DirectionRotate(transform, _rotationSpeed);
        _meshRotator = new NavMeshRotator(agent, directionRotate);
    }

    private void Update()
    {
        if (_character.Health.IsDead)
            return;

        _meshRotator.Update(Time.deltaTime);  
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
}
        


   

        
