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
    [SerializeField] private TMP_Text coinOverScore;

    [SerializeField] private GameObject gameCompleteScreen;
    [SerializeField] private TMP_Text coinCompleteScore;

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
        coinOverScore.text = "COINS x" + coins;
    }

    public void StartGameComplete(int coins)
    {
        hud.SetActive(false);
        gameCompleteScreen.SetActive(true);
        coinCompleteScore.text = "COINS x" + coins;
    }
}
