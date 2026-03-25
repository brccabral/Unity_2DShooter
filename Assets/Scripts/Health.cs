public class Health
{
    public float healthPoints { get; private set; }

    public Health(float value)
    {
        healthPoints = value;
    }

    public void IncreaseHealth(float amount)
    {
        healthPoints += amount;
    }

    public void DecreaseHealth(float amount)
    {
        healthPoints -= amount;
    }
}
