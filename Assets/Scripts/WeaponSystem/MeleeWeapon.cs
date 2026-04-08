using UnityEngine;

public class MeleeWeapon : Weapon
{
    private float range;

    public MeleeWeapon(float newDamage, float newRange) : base(newDamage)
    {
        range = newRange;
    }

    public override void Use()
    {
        Debug.Log("Slash");
    }
}
