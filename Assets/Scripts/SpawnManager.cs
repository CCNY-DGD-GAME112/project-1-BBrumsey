using UnityEngine;

/*
Spawn Manager:
This script controls zombie spawning. It keeps track of how many zombies are alive and increases the difficulty by speeding them up as the player gets more kills.
*/

public class SpawnManager : MonoBehaviour
{
    public float spawnCooldown = 1.7f;
    public GameObject zombiePrefab;
    public int targetAlive = 1;
    private int aliveCount = 0;
    private float nextSpawnTime = 0;
    public float startingZombieSpeed = 2;
    public float speedIncreasePerKill = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (aliveCount < targetAlive && Time.time >= nextSpawnTime)
        {

            SpawnOneZombie();
            aliveCount++;
            nextSpawnTime = Time.time + spawnCooldown;


        }

    }

    public void OnZombieKilled()
    {
        aliveCount = Mathf.Max(0, aliveCount - 1);
        targetAlive++;
    }



    void SpawnOneZombie()
    {
        float spawnX = Random.Range(-8f, 8f);
        float spawnY = 5f; // adjust to just above your camera top

        
        Vector2 spawnPos = new Vector2(spawnX + Random.Range(-0.5f, 0.5f), spawnY);

        GameObject newZombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
        EnemyController enemy = newZombie.GetComponent<EnemyController>();

        if (enemy != null && GameManager.Instance != null)
        {
            enemy.speed = startingZombieSpeed + (GameManager.Instance.GetScore() * speedIncreasePerKill);
        }
    
    }
}