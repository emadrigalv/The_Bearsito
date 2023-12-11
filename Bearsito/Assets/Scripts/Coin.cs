using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour ,IPickable
{

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();    
    }

    public void TakeIt()
    {

        uiManager.UpdateCoins();
        Destroy(gameObject);

    }

}
