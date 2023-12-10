using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Draw Gizmo, Circle parameters")]
    [SerializeField] private float moveCircle;
    [SerializeField] private float radio;
    [SerializeField] private LayerMask layerMask;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public PlayerConfig_SO playerStats;



    private float xDirection = 0;

    private enum MovementState {idle, running, jumping, falling}

    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDirection * playerStats.speed, rb.velocity.y);

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {

            rb.velocity = new Vector2(rb.velocity.x, playerStats.jumpForce);
        }

        //Play and update the player animations
        UpdatePlayerAnimations();

    }

    private void UpdatePlayerAnimations()
    {
        MovementState state;
        //Right move
        if (xDirection > 0f && IsGrounded())
        {
            sprite.flipX = false;
            state = MovementState.running;
        }

        //Left move
        else if (xDirection < 0f && IsGrounded())
        {
            sprite.flipX = true;
            state = MovementState.running;
        }

        // Jumping
        else if (!IsGrounded())
        {
            state = MovementState.jumping;
        }

        //Falling
        else if (rb.velocity.y > 1)
        {
            state = MovementState.falling;
        }

        // Idle
        else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", (int)state);
    }


    //Player is jumping or is in the groud verification functions

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x - 0.1f, transform.position.y + moveCircle), radio, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - 0.1f, transform.position.y + moveCircle), radio);
    }
}
