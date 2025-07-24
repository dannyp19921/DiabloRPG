using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject enemyPrefab;
    public int maxEnemies = 4;
    public float spawnDelay = 2f;
    
    [Header("Spawn Area")]
    public float spawnRadius = 8f;
    
    private int currentEnemies = 0;
    private float nextSpawnTime;
    
    void Start()
    {
        // Count existing enemies at start
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    
    void Update()
    {
        // Spawn new enemy if below max and time has passed
        if (currentEnemies < maxEnemies && Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
    
    void SpawnEnemy()
    {
        // Random position around spawner
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            currentEnemies++;
            Debug.Log("Enemy spawned! Total: " + currentEnemies);
        }
    }
    
    public void EnemyDied()
    {
        currentEnemies--;
        Debug.Log("Enemy died! Remaining: " + currentEnemies);
    }
}