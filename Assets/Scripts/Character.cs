using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;

    public bool isDead;
    public Health health;

    protected Vector2 moveDirection;

    protected virtual void Start()
    {
        health = new Health(100);
        isDead = false;
    }

    protected void Move()
    {
        rb.AddForce(moveDirection * (moveSpeed * Time.deltaTime));
    }

    protected void Rotate(Vector3 rotationTarget)
    {
        transform.up = rotationTarget - transform.position;
    }

    protected virtual void Attack()
    {
    }
}
