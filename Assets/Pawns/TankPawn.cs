using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public Transform.component firepointTransform;
    

    // Start is called before the first frame update
    public override void Start()
    {
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
