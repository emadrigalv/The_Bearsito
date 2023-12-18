using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ITrap
{
    private Animator animator;
    private BoxCollider2D col;

    private void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    public void KillPlayer()
    {
        animator.SetBool("activateTrap", true);
        col.enabled = false;
        GameManager.Instance.ReduceLives();
    }
}
