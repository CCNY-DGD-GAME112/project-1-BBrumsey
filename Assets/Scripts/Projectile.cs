using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.Die(); // This handles score + OnZombieKilled
            else
                Destroy(other.gameObject); // Fallback

            Destroy(gameObject);
        }
    }
}