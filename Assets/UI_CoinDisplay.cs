using System;
using UnityEngine;
using TMPro;

public class UI_CoinDisplay : MonoBehaviour
{
    public CoinComponent coinComponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //textComponent.text = "Coins: ".ToString();
        coinComponent.OnCoinsInitialized += OnCoinsInitialized;
        coinComponent.OnCoinsChanged += OnCoinsChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCoinsInitialized(float Coins)
    {
        textComponent.text = "Coins: " + Coins.ToString();
    }

    private void OnCoinsChanged(float newCoins, float amountChange)
    {
        textComponent.text = "Coins: " + newCoins.ToString();
    }
}
