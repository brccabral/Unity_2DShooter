using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    private AudioManager _audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            CollectPickup(other.attachedRigidbody.GetComponent<Character>());
        }
    }

    public void SetAudioManager(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    protected virtual void CollectPickup(Character receiver)
    {
        _audioManager.PlayPowerUpSound(pickupSound);
        Destroy(gameObject);
    }
}
