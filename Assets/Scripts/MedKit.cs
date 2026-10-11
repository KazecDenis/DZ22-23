using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        IHeal player = other.GetComponent<IHeal>();

        if (player != null)
        {
            if (player.Heal(_healAmount))
            {
                Destroy(gameObject);
            }
        }
    }
}
