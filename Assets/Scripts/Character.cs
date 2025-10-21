using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Arttributes
    private int health;

    // Property
    public int Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    // Initialize variable
    public void Initialized(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is spawned with initialized health: {this.Health}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamge(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage. Current Health: {Health}");

        IsDead();
    }
    
    public bool IsDead() // Bool method need to return true and false
    {
        if (Health <= 0)
        {
            Destroy(this);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
