using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour ,IPickable
{
    public void TakeIt()
    {
        Destroy(gameObject);
    }

}
