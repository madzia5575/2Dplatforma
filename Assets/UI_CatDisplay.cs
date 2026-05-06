using System;
using UnityEngine;
using TMPro;

public class UI_CatDisplay : MonoBehaviour
{
    public CatComponent catComponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        catComponent.OnCatsInitialized += OnCatsInitialized;
        catComponent.OnCatsChanged += OnCatsChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCatsInitialized(float Cats)
    {
        textComponent.text = "Cats: " + Cats.ToString();
    }

    private void OnCatsChanged(float newCats, float amountChange)
    {
        textComponent.text = "Cats: " + newCats.ToString();
    }
}
