using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform weaponTip;
    private bool canShoot = true;

    protected override void Start()
    {
        base.Start();
        canShoot = true;
    }

    protected override void Attack()
    {
        if (canShoot)
        {
            currentWeapon.Use(weaponTip, gameManager, tag);
            canShoot = false;
            Invoke(nameof(allowShoot), currentWeapon.GetCooldown());
        }
    }

    private void allowShoot()
    {
        canShoot = true;
    }
}
