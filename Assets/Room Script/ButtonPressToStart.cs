using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonPressToStart : MonoBehaviour
{
    
    public void ChangeToMainMenu ()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateMainMenuScreen();
        }
    }

    public void ChangeTOTitleScreen()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateTitleScreen();
        }
    }

    public void ChangeToCreditScreen()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateCreditScreen();
        }
    }

    public void ChangeToGameplay()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateGameplay();
        }
    }

    public void ChangeToGameOverScreen()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateGameOverScreen();
        }
    }

    public void ChangeToOptionsScreen()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateOptionsScreen();
        }
    }
}
