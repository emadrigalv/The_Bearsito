using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IPickable
{
    public void TakeIt()
    {
        GameManager.instance.Addlives();
        Destroy(gameObject);
    }
}
