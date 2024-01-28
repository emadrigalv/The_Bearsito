using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] private LevelLoader load;

    public void PlayGame()
    {
        PersistantData.instance.SetInitialData();
        load.LoadNextLevel();
    }

    public void QuitGame()
    {
        //Debug.Log("Quit!");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
