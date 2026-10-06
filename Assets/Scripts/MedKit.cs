using UnityEngine;

public class MedKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        CharacterBehavior player = other.GetComponent<CharacterBehavior>();

        if (player != null)
        {
            player.Heal();
            Debug.Log("вижу игрока");
            Destroy(gameObject);
        }
    }
}
