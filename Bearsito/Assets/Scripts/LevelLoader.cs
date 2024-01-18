using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    [SerializeField] private float transitionTime = 0.5f;

    private float gameOverScreenTime = 1.5f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }  

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(gameOverScreenTime);
        SceneManager.LoadScene("Menu");
    }
    
}
