 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;

    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject ShellPrefab;

    public GameObject enemyControllerPrefab;
    public GameObject enemyPawnPrefab;
    

    //List that holds our player(s)
    public List<PlayerController> player;
    public List<Controller> controller;

    public int spawnedPowerups;
    public int maxPowerups;

    //  Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;


    private void Start()
    {
        // Temp Code - For now, we spawn player as soon a sthe GameManager starts
        SpawnPlayer();

        //Spawn enemy pawn as soo as the Gamemanager starts
        SpawnEnemy();

        // Set the correct state at the start of the game
        ActivateMainMenuScreen();
    }

    // Awake is called when the objct is first created - before even Start can Run!
    private void Awake()
    {
        //If the instance doest exist yet...
        if (instance == null)
        {
            //this is the instance
            instance = this;
            // Dont destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Otherwise there is already and instance, so destroy this gameObject
            Destroy(gameObject);
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
              
    }



    public void SpawnPlayer()
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;

        //Hook them up!
        newController.pawn = newPawn;
    }
    
    public void SpawnEnemy()
    {
        // Spawn the Enemy controller at (0, 0, 0) with no rotation
        GameObject newPlayerObj = Instantiate(enemyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(enemyPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        //Get the Enemy controller component and pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;


    }


    private void DeactivateAllStates()
    {
        // Deactavate all game states
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        // Deactavate all states
        DeactivateAllStates();

        //Activate the title screen
        TitleScreenStateObject.SetActive(true);
                
    }

    public void ActivateOptionsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        
        // Activate the option screen
        OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateMainMenuScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the Main Menu screen
        MainMenuStateObject.SetActive(true);
    }

    public void ActivateCreditScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        //Activate the Credit Screen
        CreditsScreenStateObject.SetActive(true);

    }

    public void ActivateGameplay()
    {
        // Deactivate all states
        DeactivateAllStates();
        
        // Activate the Gameplay 
        GameplayStateObject.SetActive(true);
    }

    public void ActivateGameOverScreen()
    {
        // Deactivate alll states
        DeactivateAllStates();

        //Activate the GameOver screen
        GameOverScreenStateObject.SetActive(true);
    }

}
