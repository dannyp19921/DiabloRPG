using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // Get input using new Input System
        movement = Vector2.zero;
        
        if (Keyboard.current.wKey.isPressed) movement.y = 1;
        if (Keyboard.current.sKey.isPressed) movement.y = -1;
        if (Keyboard.current.aKey.isPressed) movement.x = -1;
        if (Keyboard.current.dKey.isPressed) movement.x = 1;
        
        // Debug
        if (movement != Vector2.zero)
        {
            Debug.Log("Movement: " + movement);
        }
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}