using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private TMP_Text amountCoins;
    [SerializeField] private TMP_Text amountLives;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text coinScore;

    public void UpdateLives(int actualLives)
    {
        amountLives.text = "x " + actualLives;
    }

    public void UpdateCoins(int coinsCollected)
    {
        amountCoins.text = "x " + coinsCollected;
    }

    public void StartGameOver(int coins)
    {
        hud.SetActive(false);
        gameOverScreen.SetActive(true);
        coinScore.text = "COINS x" + coins;
    }
}
