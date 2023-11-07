 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public Transform playerSpawnTransform;

    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject ShellPrefab;

    public GameObject patrolAIControllerPrefab;
    public GameObject attackerAIControllerPrefab;
    public GameObject guardAIControllerPrefab;
    public GameObject cowardAIControllerPrefab;

    public GameObject patrolAIPawnPrefab;
    public GameObject attackerAIPawnPrefab;
    public GameObject guardAIPawnPrefab;
    public GameObject cowardAIPawnPrefab;

    //List that holds our player(s)
    public List<PlayerController> player;

    // list that holds our ai 
    public List<PatrolAI> AIPatrolList;
    public List<GuardAI> AIGuardList;
    public List<AttackerAI> AIAttackerList;
    public List<CowardAI> AICowardList;

    

    public int spawnedPowerups;
    public int maxPowerups;

    //  Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;

    public PlayerSpawner[] spawnPoints;

    public MapGenerator mapGenerator;

    private void Start()
    {
        // Temp Code - For now, we spawn player as soon a sthe GameManager starts
        //SpawnPlayer();

        //FindObjectsOfType<PawnSpawnPoint>();

        //Spawn enemy pawn as soo as the Gamemanager starts
        //SpawnEnemy();

        // Set the correct state at the start of the game
        ActivateTitleScreen();

        mapGenerator = GetComponent<MapGenerator>();

        mapGenerator.GenerateMap();

        spawnPoints = FindObjectsOfType<PlayerSpawner>();

        foreach(PlayerSpawner p in spawnPoints)
        {
            Debug.Log(p.gameObject.name);

        }


        // spawn the patrol ai
        SpawnPatrolAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        // spawn the guard ai
        SpawnGuardAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        //spawn the attacker ai
        SpawnAttackerAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        // Spawn the coward ai
        SpawnCowardAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        // spawn the patrol ai
        SpawnPatrolAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        // spawn the guard ai
        SpawnGuardAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        //spawn the attacker ai
        SpawnAttackerAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        // Spawn the coward ai
        SpawnCowardAI(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        //Spawn the Player Tank
        SpawnPlayer(spawnPoints[Random.Range(0, spawnPoints.Length)]);

        
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



    public void SpawnPlayer(PlayerSpawner spawnPoint)
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //test intialalization
        newPawn.damageDone = 10.0f;

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;

        newPawnObj.AddComponent<PowerupManager>();

        //Hook them up!
        newController.pawn = newPawn;
        newPawn.controller = newController;
    }
    
    public void SpawnPatrolAI(PlayerSpawner spawnPoint)
    {
        // Spawn the Enemy controller at (0, 0, 0) with no rotation
        GameObject newAIObj = Instantiate(patrolAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(patrolAIPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Get the AI controller component and pawn component
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        //test intialalization
        newPawn.damageDone = 10.0f;

        newAIObj.GetComponent<PatrolAI>().waypoint[0] = spawnPoint.transform;
        newAIObj.GetComponent<PatrolAI>().waypoint[1] = spawnPoint.nextWaypoint.transform;
        newAIObj.GetComponent<PatrolAI>().waypoint[2] = spawnPoint.nextWaypoint.nextWaypoint.transform;
        newAIObj.GetComponent<PatrolAI>().waypoint[3] = spawnPoint.nextWaypoint.nextWaypoint.nextWaypoint.transform;
    }

    public void SpawnGuardAI(PlayerSpawner spawnPoint)
    {
        // Spawn the Enemy controller at (0, 0, 0) with no rotation
        GameObject newAIObj = Instantiate(guardAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(guardAIPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Get the AI controller component and pawn component
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        //test intialalization
        newPawn.damageDone = 10.0f;
    }

    public void SpawnCowardAI(PlayerSpawner spawnPoint)
    {
        // Spawn the Enemy controller at (0, 0, 0) with no rotation
        GameObject newAIObj = Instantiate(cowardAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(cowardAIPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Get the AI controller component and pawn component
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        //test intialalization
        newPawn.damageDone = 10.0f;
    }

    public void SpawnAttackerAI(PlayerSpawner spawnPoint)
    {
        // Spawn the Enemy controller at (0, 0, 0) with no rotation
        GameObject newAIObj = Instantiate(attackerAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(attackerAIPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        //Get the AI controller component and pawn component
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        //test intialalization
        newPawn.damageDone = 10.0f;
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
