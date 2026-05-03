using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Transform weaponTip;

    [SerializeField] private Weapon weaponOption1;
    [SerializeField] private Weapon weaponOption2;
    [SerializeField] private Weapon weaponOption3;
    private float shootCountdown;
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
            if (Input.GetMouseButton(0))
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(weaponOption3);
        }
    }

    public void Reset()
    {
        health.SetHealthPoints(maxHealth);
        transform.position = new Vector2(0, 0);
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
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
        currentWeapon.Use(weaponTip, gameManager, tag);
        shootCountdown = currentWeapon.GetCooldown();
    }

    private void EndGame()
    {
        gameManager.GameOver();
        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
