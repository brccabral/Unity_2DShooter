public class KamikazeEnemy : Enemy
{
    protected override void Attack()
    {
        _player.health.DecreaseHealth(damage);
        health.DecreaseHealth(health.GetHealthPoints() + 1);
    }
}
