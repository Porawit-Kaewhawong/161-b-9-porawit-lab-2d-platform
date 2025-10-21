using UnityEngine;

public class Crocodile : Enemy
{
    public override void Behavoir()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
