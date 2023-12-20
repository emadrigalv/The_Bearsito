using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ITrap
{

    public void KillPlayer()
    {
        GameManager.Instance.ReduceLives();
    }
}
