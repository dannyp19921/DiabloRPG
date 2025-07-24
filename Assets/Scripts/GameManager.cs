using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI coinCounterText;
    
    [Header("Game Stats")]
    public int totalCoins = 0;
    
    public static GameManager instance; // Singleton pattern
    
    void Awake()
    {
        // Make this accessible from other scripts
        instance = this;
    }
    
    void Start()
    {
        UpdateCoinUI();
    }
    
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinUI();
        Debug.Log("Total coins: " + totalCoins);
    }
    
    void UpdateCoinUI()
    {
        if (coinCounterText != null)
        {
            coinCounterText.text = "Coins: " + totalCoins;
        }
    }
}