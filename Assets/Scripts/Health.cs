public class Health
{
    private float healthPoints;

    public Health(float value)
    {
        healthPoints = value;
    }

    public float GetHealthPoints()
    {
        return healthPoints;
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
