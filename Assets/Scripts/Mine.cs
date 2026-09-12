using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _explosionRadius = 3f;
   [SerializeField] private float _triggerRadius = 3f;
   [SerializeField] private float _explosionDelay = 3f;
   [SerializeField] private ParticleSystem _explosionEffect;
    private bool _isExplode;
   private bool _isActivate;
   private float _timer;


    private void Update()
    {
        if (_isActivate)
        {
            UpdateTimer();
            return;
        }

        CheckTrigger();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _triggerRadius);
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);    
    }
    private void CheckTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _triggerRadius);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if(damageable != null)
            {
                _isActivate = true;
                Debug.Log("мина активирована");
                return;
            }
        }    
    }
    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
        Debug.Log($"до взрыва осталось {_explosionDelay - _timer}");

        if (_timer >= _explosionDelay)
        {
            Explode();
        }
    } 
    private void PlayExplodeEffect()
    {
        _explosionEffect.transform.SetParent(null);
        _explosionEffect.Play();
    }
    private void Explode()
    {
        if (_isExplode)
            return;


        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if(damageable != null)
                damageable.TakeDamage(_damage);
        }

        _isExplode = true;
        PlayExplodeEffect();
        Destroy(gameObject);
        Debug.Log("Взрыв");
    }
}
                

