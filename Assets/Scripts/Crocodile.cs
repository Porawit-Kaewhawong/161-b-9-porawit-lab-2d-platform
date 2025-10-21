using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] float atkRange;
    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(50);
        DamageHit = 30;

        // Set attack range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }

    public override void Behavior()
    {
        // Find distance between Croccodile and Player
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log($"{this.name} shoots rock to the {player.name}!");
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
