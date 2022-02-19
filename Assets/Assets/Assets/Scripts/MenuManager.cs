using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Button newGame;
    [SerializeField]
    public Button Setting;
    [SerializeField]
    public Button BackToMainMenu;
    [SerializeField]
    public Button Exit;

    [SerializeField]
    public GameObject setting;
    [SerializeField]
    public GameObject dead;
    public GameManager gm = GameManager.Instance;

    private void Awake() {
        GameManager.GameStateChanged += StateChanged;
        DontDestroyOnLoad(dead);
    }

    private void Update() {
        GameManager.GameStateChanged += StateChanged;
    }

    public void OnDestroy() {
        GameManager.GameStateChanged -= StateChanged;

    }

    public void StateChanged(GameState state)
    {
        if(state == GameState.MainMenu)
        {
            dead.SetActive(false);
            startMainMenu();
        }
        if(state == GameState.PauseMenu)
        {
            openSetting();
        }
        if(state == GameState.Death)
        {
            showDeathMenu();
        }
    }

    public void startMainMenu()
    {
        newGame.onClick.AddListener(transitionToNewGame);
        Setting.onClick.AddListener(transitionToSetting);
    }

    public void openSetting()
    {  
        setting.SetActive(true);
    }

    public void transitionToNewGame()
    {
        if(gm != null)
        {
            gm.updateGameState(GameState.StartLevel);
        }
        else
        {
            GameManager gm = GameManager.Instance;
            gm.updateGameState(GameState.StartLevel);
        }
    }

    public void transitionToMainMenu()
    {
        if(gm != null)
        {
            gm.updateGameState(GameState.BackToManu);
        }
        else
        {
            GameManager gm = GameManager.Instance;
            gm.updateGameState(GameState.BackToManu);
        }
    }


    public void transitionToSetting()
    {
        if(gm != null)
        {
            gm.updateGameState(GameState.PauseMenu);
        }
        else
        {
            GameManager gm = GameManager.Instance;
            gm.updateGameState(GameState.PauseMenu);
        }  
       
    }

    public void showDeathMenu()
    {
        dead.SetActive(true);
    }

    public void transitionToExit() {
        if(gm != null)
        {
            gm.updateGameState(GameState.Exit);
        }
        else
        {
            GameManager gm = GameManager.Instance;
            gm.updateGameState(GameState.Exit);
        }

       
    }
    
}
