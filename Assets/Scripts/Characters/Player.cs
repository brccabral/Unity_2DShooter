using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Weapon initWeapon;
    private Timer timer;

    private float shootCountdown;
    private Weapon currentWeapon;
    private int nukesCount;

    protected override void Start()
    {
        base.Start();

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
            if ((timer && timer.GetTimeLeft() > 0 && Input.GetMouseButton(0)) || Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
        else
        {
            shootCountdown -= Time.deltaTime;
        }

        if (nukesCount > 0 && Input.GetMouseButtonDown(1))
        {
            UseNuke();
        }
    }

    public void Reset()
    {
        health.SetHealthPoints(maxHealth);
        EquipWeapon(initWeapon);
        transform.position = new Vector2(0, 0);
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
        nukesCount = 0;
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
        if (currentWeapon)
        {
            currentWeapon.Use(weaponTip, gameManager, tag);
            shootCountdown = currentWeapon.GetCooldown();
        }
    }

    private void EndGame()
    {
        gameManager.GameOver();
        if (timer)
        {
            Destroy(timer.gameObject);
            timer = null;
        }

        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void AddNuke()
    {
        if (nukesCount > 2)
        {
            return;
        }

        nukesCount++;
    }

    public int GetNukesCount()
    {
        return nukesCount;
    }

    private void UseNuke()
    {
        gameManager.Nuke();
        nukesCount--;
    }

    public void SetTimer(Timer newTimer)
    {
        timer = newTimer;
    }
}
