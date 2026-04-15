using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float projectileSpeed;
    private float damage;

    public void SetDamage(float value)
    {
        damage = value;
    }
    
    private void Start()
    {
        rb.linearVelocity = transform.up * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().health.DecreaseHealth(damage);
            }
        }

        Destroy(gameObject);
    }
}
