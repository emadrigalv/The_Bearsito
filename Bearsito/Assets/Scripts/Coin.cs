using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickable
{
    public void TakeIt()
    {
        GameManager.instance.AddCoin();
        Destroy(gameObject);
    }

}
