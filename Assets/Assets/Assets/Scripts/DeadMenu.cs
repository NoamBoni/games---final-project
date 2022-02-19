using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadMenu : MenuManager
{
    void Update()
    {

        dead.SetActive(true);
        activateDeathMenu();
    }

    private void activateDeathMenu()
    {
        // BackToMainMenu.onClick.AddListener(backToMenu);
        Exit.onClick.AddListener(exit);
        
    }

    private void backToMenu()
    {
        this.gameObject.SetActive(false); 
        transitionToMainMenu();
    }

    private void exit()
    {
        this.gameObject.SetActive(false); 
        transitionToExit();
    }
}
