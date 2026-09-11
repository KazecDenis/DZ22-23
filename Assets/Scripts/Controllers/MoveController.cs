using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private TryGoRay _ray;
    private NavMeshMovement _movement;
    private DirectionRotate _rotator;
    private NavMeshRotator _navMeshRotator;
    [SerializeField] private GameObject _moveFlagGameObject;
    [SerializeField] private float _rotateSpeed;
    private GameObject _moveFlag;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _ray = new TryGoRay();  
        _moveFlag = Instantiate(_moveFlagGameObject);
        _moveFlag.SetActive(false);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        _movement = new NavMeshMovement(agent);

        _rotator = new DirectionRotate(transform, _rotateSpeed);
        _navMeshRotator = new NavMeshRotator(agent, _rotator);
    }

    private void Update()
    {
        if (_playerInput.IsLeftMouseButton())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 position;
           

            if (_ray.GoRay(ray, out position))
            {   
                _moveFlag.SetActive(true);
                _moveFlag.transform.position = position;
                _movement.TrySetDestination(position);
            } 
        }

        _navMeshRotator.Update(Time.deltaTime);
    }
}
                
               
                
                
                    
                
