using System;
using UnityEngine;
using TMPro;

public class UI_HealthDisplay : MonoBehaviour
{
    public HealthComponent healthComponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //textComponent.text = "Health: ".ToString();
        healthComponent.OnHealthInitialized += OnHealthInitialized;
        healthComponent.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthInitialized(float Health)
    {
        textComponent.text = "Health: " + Health.ToString();
    }

    private void OnHealthChanged(float newHealth, float amountChange)
    {
        //Debug.Log(newHealth + ":" + amountChange);
        textComponent.text = "Health: " + newHealth.ToString();
    }
}
