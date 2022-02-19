using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string level = "Level-1"; //Placeholder!!!
    private void Awake() {
        GameManager.GameStateChanged += StateChanged;
        Debug.Log("created");
    }

    public void OnDestroy() {
        GameManager.GameStateChanged -= StateChanged;
        Debug.Log("destroyed");
    }

    public void StateChanged(GameState state)
    {
        
       if(state == GameState.StartLevel)
       {
            startGame();
       }
        if(state == GameState.BackToManu)
       {
           Debug.Log("mainstate");
            startMainMenu();
       }
    }

    public void startGame()
    {
        if(level != null)
        {
            SceneManager.LoadScene(level);
            OnDestroy();
        }
    }

    public void startMainMenu()
    {
        Debug.Log("start menu");
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.updateGameState(GameState.BackToManu);
        OnDestroy();
    }


}