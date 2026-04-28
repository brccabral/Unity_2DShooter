using UnityEngine;

[CreateAssetMenu(menuName = "New Ranged Weapon")]
public class RangedWeapon : Weapon
{
    [SerializeField] private Projectile projectPrefab;
    private AudioManager audioManager;

    public override void Use(Transform weaponTip, GameManager gameManager)
    {
        var projectile = Instantiate(projectPrefab, weaponTip.position, weaponTip.rotation);
        projectile.SetDamage(damage);
        projectile.transform.SetParent(gameManager.projectileHolder);

        if (!audioManager)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }

        audioManager.PlayShootingSound(useSound);
    }
}
