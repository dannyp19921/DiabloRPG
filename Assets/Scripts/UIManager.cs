using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider healthBar;
    
    private Health playerHealth;
    
    void Start()
    {
        // Find player's health component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }
    
    void Update()
    {
        if (playerHealth != null && healthBar != null)
        {
            // Update health bar value (0 to 1)
            healthBar.value = playerHealth.currentHealth / playerHealth.maxHealth;
        }
    }
}