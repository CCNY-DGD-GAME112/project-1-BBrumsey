using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnCooldown = 1.7f;
    public GameObject zombiePrefab;
    public int targetAlive = 1;
    private int aliveCount = 0;
    private float nextSpawnTime = 0f;


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

        // Add slight random offset so zombies don't stack exactly
        Vector2 spawnPos = new Vector2(spawnX + Random.Range(-0.5f, 0.5f), spawnY);

        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}