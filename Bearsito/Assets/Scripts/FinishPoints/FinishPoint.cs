using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    [SerializeField] private LevelLoader load;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("LevelComplete", true);
            AudioManager.instance.Play("LevelComplete");
            
            PersistantData.instance.SaveData();
            //Debug.Log("Data Save");
            
            load.LoadNextLevel();
        }
    }

}
