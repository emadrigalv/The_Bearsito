using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompletePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameComplete();
            AudioManager.instance.Play("GameFinished");   
        }
    }
}
