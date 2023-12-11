using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text amountCoins;
    [SerializeField] private int coinsCollected = 0;
    public void UpdateLives()
    {

    }

    public void UpdateCoins()
    {
        coinsCollected++;

        amountCoins.text = "x " + coinsCollected;
    }

}
