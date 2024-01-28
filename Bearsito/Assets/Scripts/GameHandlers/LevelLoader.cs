using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    [SerializeField] private float transitionTime = 0.5f;

    private float gameOverScreenTime = 1.5f;
    private float gameCompleteScreenTime = 3f;

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

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(gameOverScreenTime);
        SceneManager.LoadScene("Menu");
    }
    
    public void GameComplete()
    {
        StartCoroutine(GameCompleteCoroutine());
    }

    private IEnumerator GameCompleteCoroutine()
    {
        yield return new WaitForSeconds(gameCompleteScreenTime);
        SceneManager.LoadScene("Menu");
    }
}
