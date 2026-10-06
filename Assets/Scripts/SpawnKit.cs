using System.Collections;
using UnityEngine;

public class SpawnKit : MonoBehaviour
{
   [SerializeField] private Transform _player;
   [SerializeField] private float _spawnInterval;
   [SerializeField] private GameObject _kit;
   [SerializeField] private float _spawnDistance;
   private bool _isActiveSpawn = false;
   private Coroutine _spawnCoroutine;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.F))
      {
         if (_isActiveSpawn)
         {
            Debug.Log("Spawn Off");
            _isActiveSpawn = false;
            StopCoroutine(_spawnCoroutine);
         }
         else
         {
            Debug.Log("Spawn ON");
            _isActiveSpawn = true;
            _spawnCoroutine = StartCoroutine(SpawnMedKit());
         }  
      }
    }

   private IEnumerator SpawnMedKit()
   {
      while (_isActiveSpawn)
      {
         yield return new WaitForSeconds(_spawnInterval);
         Vector2 randomPoint = Random.insideUnitCircle.normalized;
         Vector3 direction = new Vector3(randomPoint.x, 0.2f, randomPoint.y);
         Vector3 spawnPosition = _player.position + direction * _spawnDistance;
         Instantiate(_kit, spawnPosition, Quaternion.identity);
      }
   }

   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(_player.position, _spawnDistance);
   }
}
