using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet {  get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(100);
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamge(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Take damage
            OnHitWith(enemy);
            Debug.Log($"{this.name} collides with {enemy.name}");
        }
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null) banana.InitWeapon(20, this);

            WaitTime = 0.0f;
        }
    }
}
