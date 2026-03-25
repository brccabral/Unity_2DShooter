using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public bool isDead;
    public Health health;

    private void Start()
    {
        health = new Health(100);
        Debug.Log(health.healthPoints);
    }

    public void Move()
    {
    }

    public void Dash()
    {
    }

    public void Attack()
    {
    }
}
