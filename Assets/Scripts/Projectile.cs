using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab;



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
            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(1);
            Object.FindFirstObjectByType<SpawnManager>().OnZombieKilled();

            Destroy(other.gameObject); // Destroys the zombine on contact
            Destroy(gameObject); // Destroys the projectile on contact
            
        }
    }
}
