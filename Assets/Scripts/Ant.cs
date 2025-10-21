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
        velocity = new Vector2(-1.0f, 0.0f);
    }

    public override void Behavior()
    {
        //move from current position
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        //move left ����Թ�ͺ����
        if (velocity.x < 0 && rb.position.x <= MovePoints[0].position.x)
        {
            Flip();
        }
        //move right ����Թ�ͺ���
        if (velocity.x > 0 && rb.position.x >= MovePoints[1].position.x)
        {
            Flip();
        }
    }
    //flip ant to the opposite direction
    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
                          //Flip the image
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
