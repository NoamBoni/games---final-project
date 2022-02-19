using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    public GameObject settingMenuPrefab;
    [SerializeField]
    public GameObject MenuPrefab;
    public GameState State;
    public GameObject winningMenuPrefab;
    public static event Action<GameState> GameStateChanged; 

    private void Awake() {
        Instance = this;
    }
    public void Start() {
        updateGameState(GameState.MainMenu);
    }

    public void updateGameState(GameState state){
        State = state;
        switch (state)
        {
            case GameState.MainMenu:
                startMainMenu();
                break;
            case GameState.PauseMenu:
                popPasueMenu();
                break;
            case GameState.StartLevel:
                startGame();
                break;
            case GameState.Death:
                death();
                break;
            case GameState.Victory:
                victory();
                break;        
            case GameState.BackToManu:
                backMainMenu();   
                break; 
            case GameState.Exit:
                exit();
                break;                        
            default:
                break;
        }

        GameStateChanged?.Invoke(state);

    }

    public void startMainMenu()
    {
        
    }

    public void popPasueMenu()
    {
        if (SceneManager.GetActiveScene () != SceneManager.GetSceneByName("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void startGame()
    {

    }

    private void death()
    {

    }

    private void victory()
    {
        Debug.Log("Win!");
        Instantiate(winningMenuPrefab);
    }

    private void exit() {
        Debug.Log("ive exited!");
        UnityEditor.EditorApplication.isPlaying = false;
    }   

    private void backMainMenu()
    {
        Debug.Log("back to main menu");
        Instantiate(MenuPrefab);
    }          

}
public enum GameState {
    MainMenu,
    StartLevel,
    PauseMenu,
    EndLevel,
    Death,
    Victory,
    Exit,
    BackToManu

}
