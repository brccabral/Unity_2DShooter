using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private float amount;

    protected override void CollectPickup(Character receiver)
    {
        // heal the player
        receiver.health.IncreaseHealth(amount);

        base.CollectPickup(receiver);
    }
}
