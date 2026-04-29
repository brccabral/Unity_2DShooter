using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource shootingSource;
    [SerializeField] private AudioSource powerUpSource;
    [SerializeField] private AudioSource backgroundMusic;

    public void PlayShootingSound(AudioClip shoot)
    {
        shootingSource.PlayOneShot(shoot);
    }

    public void PlayPowerUpSound()
    {
    }

    public void PlayExplosionSound()
    {
    }

    public void PlayBackgroundMusic()
    {
    }

    public void StopBackgroundMusic()
    {
    }
}
