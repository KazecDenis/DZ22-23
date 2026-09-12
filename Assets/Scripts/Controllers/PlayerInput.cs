using UnityEngine;

public class PlayerInput
{
    private const int LeftMouseButtonKeyAxis = 0;
   public bool IsLeftMouseButton() => Input.GetMouseButtonDown(LeftMouseButtonKeyAxis);
}
