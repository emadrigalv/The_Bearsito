using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public static PersistantData instance;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerConfig_SO playerData;

    private string keyValue;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void SetInitialData()
    {
        int coins = playerData.initialCoins;
        int lives = playerData.initialLives;

        keyValue = $"{coins}&{lives}";

        PlayerPrefs.SetString("key", keyValue);
    }

    public void LoadData()
    {
        if(PlayerPrefs.HasKey("key"))
        {
          
            keyValue = PlayerPrefs.GetString("key");
            
            string[] arr = keyValue.Split('&');
            gameManager.coins = Int16.Parse(arr[0]);
            gameManager.lives = Int16.Parse(arr[1]);
            //Debug.Log(gameManager.coins);
            //Debug.Log(gameManager.lives);
            gameManager.SetData(gameManager.coins, gameManager.lives);
        }
        else
        {
            Debug.Log("There is not any key");
        }
    }

    public void SaveData()
    {
        int coins = gameManager.coins;
        int lives = gameManager.lives;
        //Debug.Log("Lives from PersistanData" + lives);
        keyValue = $"{coins}&{lives}";

        //Debug.Log(keyValue);

        PlayerPrefs.SetString("key", keyValue);
    }
}
