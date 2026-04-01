using UnityEngine;

public class Player : Character
{
    // Update is called once per frame
    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }
}
