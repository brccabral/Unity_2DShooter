using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Transform weaponTip;

    [SerializeField] private Weapon weaponOption1;
    [SerializeField] private Weapon weaponOption2;
    [SerializeField] private float shootCountdown;
    private Weapon currentWeapon;

    protected override void Start()
    {
        base.Start();

        EquipWeapon(weaponOption1);

        health.OnHealthZero += EndGame;
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rotate(mousePosition);
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        if (shootCountdown <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
        else
        {
            shootCountdown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(weaponOption1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(weaponOption2);
        }
    }

    public void Dash()
    {
        rb.AddForce(moveDirection * 1000);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }

    protected override void Attack()
    {
        currentWeapon.Use(weaponTip, gameManager);
        shootCountdown = currentWeapon.GetCooldown();
    }

    private void EndGame()
    {
        gameManager.RegisterHighScore();
        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
