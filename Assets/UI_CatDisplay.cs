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

    private void Start()
    {
        textComponent.text = "Cats: " + GameManager.Instance.Cats;
    }

    private void OnDestroy()
    {
        catComponent.OnCatsInitialized -= OnCatsInitialized;
        catComponent.OnCatsChanged -= OnCatsChanged;
    }
    private void OnCatsInitialized(float Cats)
    {
        textComponent.text = "Cats: " + Cats;
    }

    private void OnCatsChanged(float newCats, float amountChange)
    {
        textComponent.text = "Cats: " + newCats;
    }
}
