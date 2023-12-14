using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; // Referencia global a un objeto en especifico - Estrategia de programacion -> Patron de diseño

    private int coins = 0;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerConfig_SO playerData;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddCoin(int coinsToAdd = 1)
    {
        coins += coinsToAdd;
        uiManager.UpdateCoins(coins);
    }

   // public void ReduceLives()
    //{   


       // uiManager.UpdateLives();
    //}
}
