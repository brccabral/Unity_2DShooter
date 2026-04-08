using UnityEngine;

public class RangedWeapon : Weapon
{
    private readonly Projectile projectPrefab;
    private readonly Transform weaponTip;
    private float fireRate;

    public RangedWeapon(
        float newDamage,
        float newFireRate,
        Projectile newProjectPrefab,
        Transform newWeaponTip
    ) : base(newDamage)
    {
        fireRate = newFireRate;
        projectPrefab = newProjectPrefab;
        weaponTip = newWeaponTip;
    }

    public override void Use()
    {
        Object.Instantiate(projectPrefab, weaponTip.position, weaponTip.rotation);
    }
}
