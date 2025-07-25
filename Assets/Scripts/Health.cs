using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    
    [Header("Visual Feedback")]
    public float flashDuration = 1.0f;     // 1 sekund - mye lengre
    public Color flashColor = Color.yellow; // Gul i stedet for r�d - mer kontrast
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Health: " + currentHealth);
        
        StartCoroutine(FlashEffect());
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    IEnumerator FlashEffect()
    {
        Debug.Log("Flash effect started!");
        
        spriteRenderer.color = flashColor;
        Debug.Log("Color changed to: " + flashColor);
        
        yield return new WaitForSeconds(flashDuration);
        
        spriteRenderer.color = originalColor;
        Debug.Log("Color changed back to original");
    }
    
    void Die()
    {
        Debug.Log(gameObject.name + " died!");
    
        if (gameObject.name.Contains("Enemy"))
        {
            // Tell spawner an enemy died
            EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
            if (spawner != null)
            {
                spawner.EnemyDied();
            }
        
            DropLoot();
            Destroy(gameObject);
        }
    }

    void DropLoot()
    {
        // Load prefab from Assets folder
        GameObject coinPrefab = Resources.Load<GameObject>("Coin");
        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
    
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}