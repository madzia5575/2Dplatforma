using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float Health = 10;
    public float maxHealth = 10;
    private bool Invincibility;

    public CoinComponent coinComponent;
    public float healthPrice = 5;
    public float healingAmount = 2;

    public delegate void OnHealthChangedHandler(float newHealth, float amountChange);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHealthInitializedHandler(float Health);
    public event OnHealthInitializedHandler OnHealthInitialized;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Health = maxHealth;
        OnHealthInitialized?.Invoke(Health);
        //coinComponent.OnCoinCountInitialized += OnCoinCountInitialized;
        coinComponent.OnCoinsChanged += OnCoinCountChanged;
    }

    private void OnCoinCountChanged(float newCoins, float amountChange)
    {
        if (newCoins >= healthPrice)
            
        {
            //Health += healingAmount;
            //OnHealthChanged?.Invoke(Health, damage);
            Debug.Log("JEDNAK DZIA£A");
            RemoveDamage(healingAmount);
            coinComponent.AddCoins(-healthPrice);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if(!Invincibility)
        {
            Health -= damage;
            //Debug.Log(Health);
            OnHealthChanged?.Invoke(Health, damage);
            Invincibility = true;
            StartCoroutine(ResetInvincibility(3));
        }

        
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    IEnumerator ResetInvincibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        Debug.Log("Reset");
        Invincibility = false;
    }

    public void RemoveDamage(float healingValue)
    {
        Health += healingValue;

        if (Health >= maxHealth)
        {
            Health = maxHealth;
        }
        //Debug.Log(Health);
        OnHealthChanged?.Invoke(Health, healingValue);
        
    }

}
