using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public abstract void Use(Transform weaponTip, GameManager gameManager);
}
