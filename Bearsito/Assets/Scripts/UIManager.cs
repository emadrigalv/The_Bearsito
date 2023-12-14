using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text amountCoins;
    [SerializeField] private TMP_Text amountLives;

    public void UpdateLives(int actualLives)
    {
        amountLives.text = "x " + actualLives;
    }

    public void UpdateCoins(int coinsCollected)
    {
        amountCoins.text = "x " + coinsCollected;
    }

}
