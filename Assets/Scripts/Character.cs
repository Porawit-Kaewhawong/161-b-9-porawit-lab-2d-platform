using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    // Arttributes
    private float health;
    private float maxHealth;
    public Image healthFillBar;

    // Property
    public float Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    // Initialize variable
    public void Initialized(float startHealth)
    {
        Health = startHealth;
        MaxHealth = startHealth;
        Debug.Log($"{this.name} is spawned with initialized health: {this.MaxHealth}");
        UpdateHealthUI();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void UpdateHealthUI()
    {
        healthFillBar.rectTransform.localScale = new Vector3(Health / MaxHealth, 1f, 1f);
    }

    public void TakeDamge(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage. Current Health: {Health}");
        UpdateHealthUI();

        IsDead();
    }
    
    public bool IsDead() // Bool method need to return true and false
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
