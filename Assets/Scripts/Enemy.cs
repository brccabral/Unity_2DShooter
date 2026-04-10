using UnityEngine;

public class Enemy : Character
{
    private Transform playerTargetTransform;

    protected override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>().transform;
        health.OnHealthZero += Die;
    }

    public virtual void Update()
    {
        moveDirection = (playerTargetTransform.position - transform.position).normalized;
        transform.up = moveDirection;
    }

    private void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Destroy(gameObject);
    }
}
