using UnityEngine;

public class Enemy : Character
{
    public int score;
    [SerializeField] private float attackDelay;
    [SerializeField] private float damage;
    [SerializeField] private float distanceToAttack;
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
        if (!playerTargetTransform)
        {
            moveDirection = Vector2.zero;
            moveSpeed = 0;

            return;
        }

        moveDirection = (playerTargetTransform.transform.position - transform.position).normalized;
        transform.up = moveDirection;

        attackTimer += Time.deltaTime;
        if (Vector2.Distance(playerTargetTransform.transform.position, transform.position) < distanceToAttack)
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
