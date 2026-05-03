using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    private AudioManager _audioManager;
    private GameManager _gameManager;

    private void Start()
    {
        _audioManager = FindAnyObjectByType<AudioManager>();
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            CollectPickup(other.attachedRigidbody.GetComponent<Player>());
        }
    }

    protected virtual void CollectPickup(Player receiver)
    {
        _audioManager.PlayPowerUpSound(pickupSound);
        _gameManager.RemovePickup(this);
    }
}
