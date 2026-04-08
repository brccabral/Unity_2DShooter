public abstract class Weapon
{
    private readonly float damage;

    protected Weapon(float newDamage)
    {
        damage = newDamage;
    }

    public abstract void Use();

    public float GetDamage()
    {
        return damage;
    }
}
