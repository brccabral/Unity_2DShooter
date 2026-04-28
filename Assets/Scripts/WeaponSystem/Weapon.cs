using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected float damage;
    [SerializeField] private float cooldown;
    [SerializeField] protected AudioClip useSound;

    public abstract void Use(Transform weaponTip, GameManager gameManager);

    public float GetCooldown()
    {
        return cooldown;
    }
}
