using UnityEngine;

public class ViewFlagMove : MonoBehaviour
{
   [SerializeField] private GameObject _flagObject;
   private GameObject _moveFlag;

    public void MoveFlagPosition (Vector3 position)
    {
        if (_moveFlag == null)
            _moveFlag = Instantiate(_flagObject, position, Quaternion.identity);
        else
            _moveFlag.transform.position = position;
    }
}
