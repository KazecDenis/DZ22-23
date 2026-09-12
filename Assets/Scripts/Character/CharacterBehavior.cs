using UnityEngine;

public class CharacterBehavior : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private MoveController _moveController;
    private Character _character;
    
    private void Awake()
    {
        _character = new Character(_maxHealth);
        _characterView.Initialize(_character);
        _moveController.Initialize(_character); 
    }

    public void TakeDamage(int damage)
    {
        if (_character.Health.IsDead)
            return;

        _character.Health.TakeDamage(damage);
        _characterView.StartTakeDamageAnimation();
        Debug.Log(_character.Health.Current);

        if (_character.Health.IsDead)
        {
            _moveController.Stop();
            _characterView.StartDeadAnimation();
        }
    }
}
        


   

        
