using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float range;

    public override void Use(Transform weaponTip, GameManager gameManager, string sourceTag)
    {
        // Debug.Log("Slash");
    }
}
