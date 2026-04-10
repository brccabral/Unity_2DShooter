using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private GameManager gameManager;

    private Weapon weaponOption1;
    private Weapon weaponOption2;
    private Weapon currentWeapon;

    protected override void Start()
    {
        base.Start();

        weaponOption1 = new RangedWeapon(2, gameManager, 5, projectilePrefab, weaponTip);
        Debug.Log($"Damage: {weaponOption1.GetDamage()}");

        weaponOption2 = new MeleeWeapon(4, gameManager, 3);
        Debug.Log($"Damage: {weaponOption2.GetDamage()}");

        EquipWeapon(weaponOption1);
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rotate(mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
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
        base.Attack();
        currentWeapon.Use();
    }
}
