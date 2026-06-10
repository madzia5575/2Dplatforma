using System.Collections;
using UnityEngine;

public class CatComponent : MonoBehaviour
{

    public delegate void OnCatsChangedHandler(float newCats, float amountChange);
    public event OnCatsChangedHandler OnCatsChanged;

    public delegate void OnCatsInitializedHandler(float Cats);
    public event OnCatsInitializedHandler OnCatsInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnCatsInitialized?.Invoke(GameManager.Instance.Cats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCats(float catValue)
    {
        //Cats += catValue;
        //Debug.Log(Coins);
        //OnCatsChanged?.Invoke(Cats, catValue);
        GameManager.Instance.Cats += (int)catValue;

        OnCatsChanged?.Invoke(GameManager.Instance.Coins,catValue);
    }
}
