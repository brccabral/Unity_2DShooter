using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    private AudioManager _audioManager;
    private GameManager _gameManager;

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

    public void SetGameManager(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    protected virtual void CollectPickup(Character receiver)
    {
        _audioManager.PlayPowerUpSound(pickupSound);
        _gameManager.RemovePickup(this);
    }
}
