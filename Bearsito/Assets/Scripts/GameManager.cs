using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; // Referencia global a un objeto en especifico - Estrategia de programacion -> Patron de diseño

    private int coins = 0;
    private int lives;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerConfig_SO playerData;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform spawnPosition;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        lives = playerData.initialLives;
    }

    public void AddCoin(int coinsToAdd = 1)
    {
        FindObjectOfType<AudioManager>().Play("Coin");
        coins += coinsToAdd;
        uiManager.UpdateCoins(coins);
    }

    public void ReduceLives()
    {
        FindObjectOfType<AudioManager>().Play("Death");
        StartCoroutine(WaitForRestart_Coroutine());
        lives--;
        uiManager.UpdateLives(lives);

    }

    IEnumerator WaitForRestart_Coroutine()
    {
        player.StopMovement();

        yield return new WaitForSeconds(1.0f);

        player.transform.position = spawnPosition.position;

        player.ActivateMovement();
    }

}
