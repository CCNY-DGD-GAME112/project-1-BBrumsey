using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D RB;
    public EnemyController Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.MoveTowards(transform.position, Target.transform.position, 0.1f);
        RB.MovePosition(move);
    }
}
