using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    public bool isDead;

    public Rigidbody2D rb;
    public Health health;

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

    public void Dash()
    {
    }

    public void Attack()
    {
    }
}
