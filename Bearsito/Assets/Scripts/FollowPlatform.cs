using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlatform : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform wayPoint1, wayPoint2; 
    [SerializeField] private PlayerController movement;
    [SerializeField] private Rigidbody2D rb;

    private Vector3 movementDirection;
    private Vector3 targetWp;

    private void Start()
    {
        targetWp = wayPoint1.position;
        CalculateDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(transform.position, targetWp) < .1f)
        {
            targetWp = targetWp == wayPoint1.position ? wayPoint2.position : wayPoint1.position;
            CalculateDirection();
        }
    }

    private void CalculateDirection()
    {
        movementDirection = (targetWp - transform.position).normalized;
        rb.velocity = movementDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            movement.ToggleInPlatform(true, rb);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            movement.ToggleInPlatform(false, null);
        }
    }
}
