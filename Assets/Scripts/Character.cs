using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected GameObject dieEffectPrefab;

    public Health health = new(100);

    protected Vector2 moveDirection;
    protected GameManager gameManager;

    protected virtual void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
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
