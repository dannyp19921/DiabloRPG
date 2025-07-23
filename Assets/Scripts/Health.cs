using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    
    [Header("Visual Feedback")]
    public float flashDuration = 1.0f;     // 1 sekund - mye lengre
    public Color flashColor = Color.yellow; // Gul i stedet for rød - mer kontrast
    
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
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Player"))
        {
            // Player died - Game Over
            Debug.Log("GAME OVER!");
            Time.timeScale = 0f; // Pause the game
            // We can add proper Game Over UI later
        }
    }
    
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}