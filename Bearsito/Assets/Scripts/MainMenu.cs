using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private LevelLoader load;

    public void PlayGame()
    {
        PersistantData.instance.SetInitialData();
        load.LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
