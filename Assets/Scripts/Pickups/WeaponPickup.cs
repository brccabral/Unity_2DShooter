using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private Weapon weapon;

    protected override void CollectPickup(Player receiver)
    {
        receiver.EquipWeapon(weapon);

        base.CollectPickup(receiver);
    }
}
