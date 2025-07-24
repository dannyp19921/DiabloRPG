using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 10;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add coins to GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.AddCoins(value);
            }
            
            Debug.Log("Player collected " + value + " coins!");
            Destroy(gameObject);
        }
    }
}