using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    [Header("Combat Settings")]
    public float attackDamage = 25f;
    public float attackRange = 1.5f;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        HandleMovement();
        HandleCombat();
    }
    
    void HandleMovement()
    {
        movement = Vector2.zero;
        
        if (Keyboard.current.wKey.isPressed) movement.y = 1;
        if (Keyboard.current.sKey.isPressed) movement.y = -1;
        if (Keyboard.current.aKey.isPressed) movement.x = -1;
        if (Keyboard.current.dKey.isPressed) movement.x = 1;
    }
    
    void HandleCombat()
    {
        // Attack on left mouse click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
        }
    }
    
    void Attack()
    {
        // Find all enemies within attack range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            
            if (distance <= attackRange)
            {
                // Deal damage to the enemy
                Health enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                    Debug.Log("Player attacked " + enemy.name + "!");
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}