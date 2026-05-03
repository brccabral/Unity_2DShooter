public class NukePickup : Pickup
{
    protected override void CollectPickup(Player receiver)
    {
        receiver.AddNuke();
        base.CollectPickup(receiver);
    }
}
