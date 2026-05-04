using UnityEngine;

public class FireRatePickup : Pickup
{
    [SerializeField] private Timer timerPrefab;

    protected override void CollectPickup(Player receiver)
    {
        var timer = Instantiate(timerPrefab, receiver.transform.position, Quaternion.identity);
        timer.SetPlayerTransform(receiver.transform);
        receiver.SetTimer(timer);

        base.CollectPickup(receiver);
    }
}
