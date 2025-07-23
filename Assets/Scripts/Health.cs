using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Health: " + currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log(gameObject.name + " died!");
        
        // If it's an enemy, destroy it
        if (gameObject.name.Contains("Enemy"))
        {
            Destroy(gameObject);
        }
        // If it's player, we can add game over logic later
    }
    
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}