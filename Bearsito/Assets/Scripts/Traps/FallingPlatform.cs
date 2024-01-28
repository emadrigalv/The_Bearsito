using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlatform : MonoBehaviour, IReloadable
{

    [SerializeField] private float fallDelay = 1.5f;
    private float disableDelay = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("Falling", true);
        AudioManager.instance.Play("FallingPlatform");
        StartCoroutine(DeactivateObject());
        //gameObject.SetActive(false);
    }

    public void ReloadObject()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        animator.Rebind();
        animator.Update(0f);
        transform.position = initialPosition;
        gameObject.SetActive(true);
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(disableDelay);
        gameObject.SetActive(false);
    }
}
