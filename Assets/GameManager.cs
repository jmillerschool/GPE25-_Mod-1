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

    //List that holds our player(s)
    public List<PlayerController> player;

    private void Start()
    {
        // Temp Code - For now, we spawn player as soon a sthe GameManager starts
        SpawnPlayer();
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
}
