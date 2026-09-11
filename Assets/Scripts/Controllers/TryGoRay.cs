using UnityEngine;

public class TryGoRay
{
    public bool GoRay(Ray ray, out Vector3 position)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            position = hit.point;
            return true;
        }

        position = Vector3.zero;
        return false;
    }
}
