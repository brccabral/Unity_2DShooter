using UnityEngine;

public class Player : Character, IDash
{
    // Update is called once per frame
    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

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
