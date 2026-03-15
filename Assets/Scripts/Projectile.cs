using UnityEngine;
/*
Projectile:
This script controls what happens when a projectile hits an enenmy.
*/ 
 
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