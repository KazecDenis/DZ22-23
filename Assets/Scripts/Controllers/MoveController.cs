using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private ViewFlagMove _viewFlagMove;
    [SerializeField] private RectTransform[] _rectTransforms;
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

            if (IsPointerOverUI())
                return;
           
            if (_ray.GoRay(ray, out position))
            {   
                _viewFlagMove.MoveFlagPosition(position);
                _movable.Move(position);
            } 
        }
    }

    private bool IsPointerOverUI()
    {
        foreach (RectTransform rectTransform in _rectTransforms)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
                return true;
        }

        return false;
    }
}
        
        
        
        
    



                
               
                
                
                    
                
