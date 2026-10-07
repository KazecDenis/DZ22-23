using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _triggerRadius = 3f;
    [SerializeField] private float _explosionDelay = 3f;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;
    private bool _isExplode;
    private bool _isActivate;

    private void Update()
    {
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
                if (!_isActivate)
                {
                    _isActivate = true;
                    StartCoroutine(ExplosionDelay());
                }

                return;
            }
        }    
    }
    private void PlayExplodeSound()
    {
        _audioSource.transform.SetParent(null);
        _audioSource.Play();
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

        PlayExplodeSound();
        _isExplode = true;
        PlayExplodeEffect();
        Destroy(gameObject);
        Debug.Log("Взрыв");
    }

    private IEnumerator ExplosionDelay()
    {
       yield return new WaitForSeconds(_explosionDelay);

       Explode();
    }
}

                


