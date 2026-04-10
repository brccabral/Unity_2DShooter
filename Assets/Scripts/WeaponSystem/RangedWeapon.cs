using UnityEngine;

public class RangedWeapon : Weapon
{
    private readonly Projectile projectPrefab;
    private readonly Transform weaponTip;
    private float fireRate;

    public RangedWeapon(
        float newDamage,
        GameManager newGameManager,
        float newFireRate,
        Projectile newProjectPrefab,
        Transform newWeaponTip
    ) : base(newDamage, newGameManager)
    {
        fireRate = newFireRate;
        projectPrefab = newProjectPrefab;
        weaponTip = newWeaponTip;
    }

    public override void Use()
    {
        var projectile = Object.Instantiate(projectPrefab, weaponTip.position, weaponTip.rotation);
        projectile.transform.SetParent(gameManager.projectileHolder);
    }
}
