using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Referencia global a un objeto en especifico - Estrategia de programacion -> Patron de diseño

    public int coins;
    public int lives;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private LevelLoader sceneLoader;

    [SerializeField] private List<GameObject> reloadableObjects;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        PersistantData.instance.LoadData();
    }

    public void AddCoin(int coinsToAdd = 1)
    {
        AudioManager.instance.Play("Coin");
        coins += coinsToAdd;
        uiManager.UpdateCoins(coins);
    }

    public void Addlives()
    {
        AudioManager.instance.Play("Apple");
        lives++;
        uiManager.UpdateLives(lives);
    }

    public void ReduceLives()
    {
        AudioManager.instance.Play("Death");
        lives--;

        if(lives < 1)
        {
            GameOver();
        }

        StartCoroutine(WaitForRestart_Coroutine());
        uiManager.UpdateLives(lives);
    }

    public void SetData(int coinsToSet, int livesToSet)
    {
        uiManager.UpdateCoins(coinsToSet);
        uiManager.UpdateLives(livesToSet);
    }

    IEnumerator WaitForRestart_Coroutine()
    {
        player.StopMovement();

        yield return new WaitForSeconds(1.0f);

        foreach(GameObject reloadable in reloadableObjects)
        {
            reloadable.GetComponent<IReloadable>().ReloadObject();
        }

        player.transform.position = new Vector3(spawnPosition.position.x+0.5f, spawnPosition.position.y+1.7f, spawnPosition.position.z);

        player.ActivateMovement();
    }
    
    public void GameOver()
    {
        uiManager.StartGameOver(coins);
        sceneLoader.GameOver();
        player.StopMovement();
    }

}
