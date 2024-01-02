using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door door;

    [SerializeField] private Animator animator; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            animator.SetBool("Pressed", true);
            AudioManager.instance.Play("ButtonPressed");

            door.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            animator.SetBool("Pressed", false);

            door.CloseDoor();   
        }
    }
}
