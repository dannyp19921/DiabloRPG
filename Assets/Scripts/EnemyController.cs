using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float moveSpeed = 2f;
    public float followDistance = 5f;
    
    [Header("Combat Settings")]
    public float attackDamage = 15f;
    public float attackCooldown = 1.0f;
    
    private Transform player;
    private Rigidbody2D rb;
    private float lastAttackTime;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            
            if (distanceToPlayer <= followDistance)
            {
                FollowPlayer();
            }
        }
    }
    
    void FollowPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Attack player when touching them
        if (other.CompareTag("Player") && Time.time > lastAttackTime + attackCooldown)
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
                Debug.Log("Enemy attacked Player!");
            }
        }
    }
}