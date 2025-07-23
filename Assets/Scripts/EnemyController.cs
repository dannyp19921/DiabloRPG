using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float moveSpeed = 2f;
    public float followDistance = 5f;
    
    private Transform player;
    private Rigidbody2D rb;
    
    void Start()
    {
        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (player != null)
        {
            // Calculate distance to player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            
            // Follow player if within range
            if (distanceToPlayer <= followDistance)
            {
                FollowPlayer();
            }
        }
    }
    
    void FollowPlayer()
    {
        // Calculate direction to player
        Vector2 direction = (player.position - transform.position).normalized;
        
        // Move towards player
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}