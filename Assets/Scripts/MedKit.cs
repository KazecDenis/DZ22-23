using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        CharacterBehavior player = other.GetComponent<CharacterBehavior>();

        if (player != null)
        {
            if (player.Heal(_healAmount))
            {
                Destroy(gameObject);
            }
        }
    }
}
