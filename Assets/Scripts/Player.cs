using UnityEngine;

public class Player : Character
{
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
            // Take Damage
            OnHitWith(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
