using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour, ITrap
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D bearTrapCollider;

    public void KillPlayer()
    {
        animator.SetBool("activateTrap", true);
        AudioManager.instance.Play("BearTrap");
        bearTrapCollider.enabled = false;
        GameManager.instance.ReduceLives();
    }
}
