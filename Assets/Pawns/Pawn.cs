using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Variable for move speed
    public float moveSpeed;

    //Variable for turn speed
    public float turnSpeed;

    //Variable for fireRate;
    public float fireRate;

    // Variable for our shell prefab
    public GameObject shellPrefab;

    // Variable for our firing force
    public float fireForce;

    // Variable for our damage done
    public float damageDone;

    // Variable for how long our bullets survive if they dont collide
    public float shellLifespan;

    // Variable for the volume of our Noisemaker
    public float noiseMakerVolume;

    

    //Variable to hold our Mover
    public Mover mover;

    //Variable to hold our shooter
    public Shooter shooter;

    // Variable to hold our NoiseMaker
    public NoiseMaker noiseMaker;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();

        shooter = GetComponent<Shooter>();

        noiseMaker = GetComponent<NoiseMaker>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public abstract void RotateTowards(Vector3 targetPosition);

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();


    public abstract void Shoot();

    public abstract void MakeNoise();

    public abstract void StopNoise();
}
