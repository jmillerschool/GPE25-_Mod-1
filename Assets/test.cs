using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public KeyCode callTitleScreenState;
    public KeyCode callMainMenuScreenState;
    public KeyCode callOptionsScreenState;
    public KeyCode callCreditScreenState;
    public KeyCode callGamePlayState;
    public KeyCode callGameOverScreenState;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(callTitleScreenState))
        {
            gameManager.ActivateTitleScreen();
        }

        if (Input.GetKeyDown(callMainMenuScreenState))
        {
            gameManager.ActivateMainMenuScreen();
        }

        if (Input.GetKeyDown(callOptionsScreenState))
        {
            gameManager.ActivateOptionsScreen();
        }

        if (Input.GetKeyDown(callCreditScreenState))
        {
            gameManager.ActivateCreditScreen();
        }

        if (Input.GetKeyDown(callGamePlayState))
        {
            gameManager.ActivateGameplay();
        }

        if (Input.GetKeyDown(callGameOverScreenState))
        {
            gameManager.ActivateGameOverScreen();
        }


    }

    
}


