using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    public Health health;

    protected Vector2 moveDirection;
    private bool isDead;

    protected virtual void Start()
    {
        health = new Health(100);
        Debug.Log(health.GetHealthPoints());
    }

    protected void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void Attack()
    {
    }
}
