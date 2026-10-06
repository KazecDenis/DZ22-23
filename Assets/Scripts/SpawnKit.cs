using UnityEngine;

public class SpawnKit : MonoBehaviour
{
   [SerializeField] private Transform _player;
   [SerializeField] private float _timer;
   private Coroutine _coroutine;
}
