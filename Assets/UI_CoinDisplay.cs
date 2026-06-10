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
    private void Start()
    {
        textComponent.text = "Coins: " + GameManager.Instance.Coins;
    }

    private void OnDestroy()
    {
        coinComponent.OnCoinsInitialized -= OnCoinsInitialized;
        coinComponent.OnCoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsInitialized(float Coins)
    {
        textComponent.text = "Coins: " + Coins;
    }

    private void OnCoinsChanged(float newCoins, float amountChange)
    {
        textComponent.text = "Coins: " + newCoins;
    }
}
