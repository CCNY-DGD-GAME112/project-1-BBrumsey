using UnityEngine;

public class Projectile : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {


            other.GetComponent<EnemyController>()?.Die(); // Destroys the zombine on contact
            Destroy(gameObject); // Destroys the projectile on contact
            
        }
    }
}
