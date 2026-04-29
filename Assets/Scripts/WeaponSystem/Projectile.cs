using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float projectileSpeed;
    private float damage;
    private string sourceTag;

    private void Start()
    {
        rb.linearVelocity = transform.up * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody)
        {
            if (!other.gameObject.CompareTag(sourceTag))
            {
                other.gameObject.GetComponent<Character>().health.DecreaseHealth(damage);
            }
        }

        Destroy(gameObject);
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    public void SetSourceTag(string value)
    {
        sourceTag = value;
    }
}
