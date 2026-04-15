using UnityEngine;

[CreateAssetMenu(menuName = "New Ranged Weapon")]
public class RangedWeapon : Weapon
{
    [SerializeField] private Projectile projectPrefab;
    [SerializeField] private float fireRate;

    public override void Use(Transform weaponTip, GameManager gameManager)
    {
        var projectile = Instantiate(projectPrefab, weaponTip.position, weaponTip.rotation);
        projectile.transform.SetParent(gameManager.projectileHolder);
    }
}
