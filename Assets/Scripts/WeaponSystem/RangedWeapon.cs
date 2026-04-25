using UnityEngine;

[CreateAssetMenu(menuName = "New Ranged Weapon")]
public class RangedWeapon : Weapon
{
    [SerializeField] private Projectile projectPrefab;

    public override void Use(Transform weaponTip, GameManager gameManager)
    {
        var projectile = Instantiate(projectPrefab, weaponTip.position, weaponTip.rotation);
        projectile.SetDamage(damage);
        projectile.transform.SetParent(gameManager.projectileHolder);
    }
}
