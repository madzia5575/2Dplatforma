using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Coins;
    public int Health = 10;
    public int Cats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetGame()
    {
        Coins = 0;
        Cats = 0;
        Health = 10;
    }
}
