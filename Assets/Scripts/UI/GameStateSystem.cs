using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateSystem : MonoBehaviour
{
    private Player _player;

    public bool gameOver;
    public bool gamePaused;
    public bool levelComplete;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        { 
            if(!gamePaused){ PauseGame(); }
            else { ResumeGame(); }
        }

        if(_player.playerDead)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void ResumeGame()
    {
        gamePaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
