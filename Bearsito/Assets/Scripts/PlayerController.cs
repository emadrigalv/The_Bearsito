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

    private bool inPlatform;
    [SerializeField] public Rigidbody2D platformRb;

    private float xDirection = 0;

    private enum MovementState {idle, running, jumping, falling}

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        PlayerMovement();
        UpdatePlayerAnimations();
    }

    private void PlayerMovement()
    {

        xDirection = Input.GetAxisRaw("Horizontal");

        if (inPlatform)
        {
            rb.velocity = new Vector2((xDirection * playerStats.speed) + platformRb.velocity.x, rb.velocity.y);
        }
        else 
        { 
            rb.velocity = new Vector2(xDirection * playerStats.speed, rb.velocity.y);
        }

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, playerStats.jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
        }
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
        else if (rb.velocity.y > 2.5f)
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

    public void StopMovement()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetBool("death", true);
    }

    public void ActivateMovement()
    {
        animator.SetBool("death", false);
        //animator.SetInteger("state", 0);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void ToggleInPlatform(bool toggle, Rigidbody2D platform)
    {
        inPlatform = toggle;
        platformRb = platform;
    }
}
