using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private ViewFlagMove _viewFlagMove;
    private PlayerInput _playerInput;
    private TryGoRay _ray;
    private IMovable _movable;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _ray = new TryGoRay();  
       
       _movable = GetComponent<IMovable>();
    }

    private void Update()
    {
        if (_playerInput.IsLeftMouseButton())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 position;
           
            if (_ray.GoRay(ray, out position))
            {   
                _viewFlagMove.MoveFlagPosition(position);
                _movable.Move(position);
            } 
        }
    }
}
        
        
        
        
    



                
               
                
                
                    
                
