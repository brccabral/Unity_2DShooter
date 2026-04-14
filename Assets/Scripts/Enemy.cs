using UnityEngine;

public class Enemy : Character
{
    public int score;
    [SerializeField] private float attackDelay;
    [SerializeField] private float damage;
    private Player playerTargetTransform;
    private float attackTimer;

    protected override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>();
        health.OnHealthZero += Die;
    }

    public virtual void Update()
    {
        moveDirection = (playerTargetTransform.transform.position - transform.position).normalized;
        transform.up = moveDirection;

        attackTimer += Time.deltaTime;
        if (Vector2.Distance(playerTargetTransform.transform.position, transform.position) < 2f)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        if (attackTimer > attackDelay)
        {
            playerTargetTransform.health.DecreaseHealth(damage);
            attackTimer = 0f;
        }
    }

    private void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Destroy(gameObject);
    }
}
