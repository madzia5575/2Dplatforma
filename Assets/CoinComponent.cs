using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    private float Coins = 0;

    public delegate void OnCoinsChangedHandler(float newCoins, float amountChange);
    public event OnCoinsChangedHandler OnCoinsChanged;

    public delegate void OnCoinsInitializedHandler(float Coins);
    public event OnCoinsInitializedHandler OnCoinsInitialized;


    //public delegate void OnCoinCountInitializedhandler(float Coins);
    //public event OnCoinCountInitializedhandler OnCoinCountInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Coins = 0;
        OnCoinsInitialized?.Invoke(Coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(float coinValue)
    { 
        Coins += coinValue;
        //Debug.Log(Coins);
        OnCoinsChanged?.Invoke(Coins, coinValue);
    }


}
