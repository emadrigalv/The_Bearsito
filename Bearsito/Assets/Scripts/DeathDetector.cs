using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            ITrap kill = collision.gameObject.GetComponent<ITrap>();

            kill.KillPlayer();
        }
    }
}

