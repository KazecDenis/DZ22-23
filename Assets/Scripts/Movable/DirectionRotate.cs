using UnityEngine;

public class DirectionRotate 
{
   private Transform _transform;
   private float _speedRotate;
   private Vector3 _currentDirection;

   public DirectionRotate(Transform transform, float speedRotate)
    {
        _transform = transform;
        _speedRotate = speedRotate;
    }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;
    public Quaternion CurrentRotate => _transform.rotation;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.02f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);
        float step = _speedRotate * deltaTime;
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
