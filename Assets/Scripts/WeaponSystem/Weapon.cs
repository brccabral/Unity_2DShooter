public abstract class Weapon
{
    private readonly float damage;
    protected GameManager gameManager;

    protected Weapon(float newDamage, GameManager newGameManager)
    {
        damage = newDamage;
        gameManager = newGameManager;
    }

    public abstract void Use();

    public float GetDamage()
    {
        return damage;
    }
}
