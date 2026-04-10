using UnityEngine;

public class MeleeWeapon : Weapon
{
    private float range;

    public MeleeWeapon(float newDamage, GameManager newGameManager, float newRange) : base(newDamage, newGameManager)
    {
        range = newRange;
    }

    public override void Use()
    {
        Debug.Log("Slash");
    }
}
