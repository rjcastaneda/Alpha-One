using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    //When you press Load Game, you load to the level you were last at.
    public void LoadButton()
    {

    }

    public void exitButton()
    {
        Debug.Log("Game has Quit!");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
