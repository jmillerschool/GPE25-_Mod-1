using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootkey;

    // Start is called before the first frame update
    public override void Start()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it Tracks the player(s)
            if (GameManager.instance.player != null)
            {
                //Register with the GameManager
                GameManager.instance.player.Add(this);
            }
        }
        
        // Run the Start() function from the parent (base) class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Process our KeyBoard Input
        ProcessInputs();    

        //Run the Update() function from the parent (base) class
        base.Update();
       
    }
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(rotateClockwiseKey)) 
        { 
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKeyDown(shootkey))
        {
            pawn.Shoot();
        }
    }
    public void OnDestroy()
    {
        // IF we have a GameManager
        if (GameManager.instance != null)
        {
            // And It tracks the player(s)
            //Deregister with the GameManager
            GameManager.instance.player.Remove(this);
        }
    }
}
