using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Vector3 up;

    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)mousePosition - transform.position;

        up = transform.up;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    public void Dash()
    {
        rb.AddForce(moveDirection * 1000);
    }
}
