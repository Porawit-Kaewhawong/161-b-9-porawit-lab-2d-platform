using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    public Transform[] MovePoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(20);
        DamageHit = 20;

        // Set speed and direction of movement
        velocity = new Vector2(-1.5f, 0.0f);
    }

    public override void Behavior()
    {
        // Move from current position
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        // Move left
        if (velocity.x < 0 && rb.position.x <= MovePoints[0].position.x)
        {
            Flip();
        }
        // Move right
        if (velocity.x > 0 && rb.position.x >= MovePoints[1].position.x)
        {
            Flip();
        }
    }

    // Flip ant to the opposite direction
    public void Flip()
    {
        velocity.x *= -1; // Change direction of movement

        // Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
