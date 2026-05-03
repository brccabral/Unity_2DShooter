using UnityEngine;

public class Enemy : Character
{
    public int score;
    [SerializeField] private float attackDelay;
    [SerializeField] protected float damage;
    [SerializeField] private float distanceToAttack;
    protected Player _player;
    private float attackTimer;

    protected override void Start()
    {
        base.Start();
        health.OnHealthZero += Die;
    }

    public virtual void Update()
    {
        if (!_player.isActiveAndEnabled)
        {
            moveDirection = Vector2.zero;
            moveSpeed = 0;

            return;
        }

        moveDirection = (_player.transform.position - transform.position).normalized;
        transform.up = moveDirection;

        attackTimer += Time.deltaTime;
        if (Vector2.Distance(_player.transform.position, transform.position) < distanceToAttack)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    protected override void Attack()
    {
        if (attackTimer > attackDelay)
        {
            _player.health.DecreaseHealth(damage);
            attackTimer = 0f;
        }
    }

    private void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
