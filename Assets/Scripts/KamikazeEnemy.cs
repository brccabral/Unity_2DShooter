public class KamikazeEnemy : Enemy
{
    protected override void Attack()
    {
        playerTargetTransform.health.DecreaseHealth(damage);
        health.DecreaseHealth(health.GetHealthPoints() + 1);
    }
}
