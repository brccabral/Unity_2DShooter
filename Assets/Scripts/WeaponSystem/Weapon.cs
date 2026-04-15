using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected float damage;

    public abstract void Use(Transform weaponTip, GameManager gameManager);

    public float GetDamage()
    {
        return damage;
    }
}
