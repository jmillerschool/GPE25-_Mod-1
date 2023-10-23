using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    private float nextEventTime;
    private float timerDelay;
    public override void Shoot()
    {
        if(Time.time >= nextEventTime)
        {
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
            nextEventTime = Time.time + timerDelay;
           
        }
        
    }


    // Start is called before the first frame update
    public override void Start()
    {
        float secondsPerShot;
        if (fireRate <= 0)
        {
            secondsPerShot = Mathf.Infinity;
        }
        else
        {          
            secondsPerShot = 1 / fireRate;              
        }
        timerDelay = secondsPerShot;
        nextEventTime = Time.time + timerDelay;

        base.Start();

    }
    
    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }
    public override void MoveForward()
    {
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }else
        {
            Debug.LogWarning("Warning :No Mover in TankPawn.MoverForward()!");
        }
        
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the Vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;

        // Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Rotate closer to that vector, but dont rotate more that our turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }

    public override void MoveBackward()
        
    {
        if (mover != null)
        {
            mover.Move(transform.forward, -moveSpeed);
        }else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveBack()!");
        }
    }
    public override void RotateClockwise()
    {
        if (mover != null)
        {
            mover.Rotate(turnSpeed);
        }
        else
            Debug.LogWarning("Warning: No Mover in TankPawn.RotateClockwise()!");
    }
    public override void RotateCounterClockwise()
    {
        if (mover != null)
        {
            mover.Rotate(-turnSpeed);
        }else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.RotateCounterClockwise()!");
        }
    }
}
