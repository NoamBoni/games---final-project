using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{    

    [SerializeField]
    public Button Exit;

    [SerializeField]
    public GameManager gm = GameManager.Instance;
    private void Start() {
        this.gameObject.SetActive(true);
    }
    void Update()
    {
        activateWinMenu();
    }

    private void activateWinMenu()
    {
        Exit.onClick.AddListener(exit); 
    }

    private void loadNextLevel()
    {
        this.gameObject.SetActive(false); 
        transitionToNextLevel();
    }

    private void exit()
    {
        this.gameObject.SetActive(false); 
        transitionToExit();
    }

    private void transitionToNextLevel()
    {
        
    }

    private void transitionToExit()
    {
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
