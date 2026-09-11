using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private CharacterView _characterView;
    private Character _character;

    private void Awake()
    {
        _character = new Character(_maxHealth);
        _characterView.Initialize(_character);  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.Health.TakeDamage(20);
        }  
        if (Input.GetKeyDown(KeyCode.F))
            _character.Health.Heal(20);
    }
}

        
