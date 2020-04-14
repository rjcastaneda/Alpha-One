using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateSystem : MonoBehaviour
{
    private Player _player;
    
    public bool gameOver;
    public bool gamePaused;
    public bool levelCompleted;
    public EnemySpawnSystem spawnSys;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject levelCompleteUI;


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

        if(spawnSys.allWavesCleared == true)
        {
            StartCoroutine(LevelComplete());
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

    public IEnumerator LevelComplete()
    {
        levelCompleted = true;
        levelCompleteUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
