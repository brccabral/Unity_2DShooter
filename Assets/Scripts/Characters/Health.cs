using System;
using UnityEngine;

public class Health
{
    public Action OnHealthZero;
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
        if (GetHealthPoints() <= 0)
        {
            OnHealthZero?.Invoke();
        }
    }

    public void SetHealthPoints(float value)
    {
        healthPoints = value;
    }
}
