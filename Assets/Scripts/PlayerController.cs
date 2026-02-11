using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public Rigidbody2D RB;
    public PlayerController Target;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        RB = GetComponent<Rigidbody2D>();
        RB.linearVelocity = new Vector2(10,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.MoveTowards(transform.position, Target.transform.position, 0.1f);
         RB.MovePosition(move);
    }
}
