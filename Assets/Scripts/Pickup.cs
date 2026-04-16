using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            CollectPickup(other.attachedRigidbody.GetComponent<Character>());
        }
    }

    protected virtual void CollectPickup(Character receiver)
    {
        // Play sound
        // Spawn effect
        Destroy(gameObject);
    }
}
