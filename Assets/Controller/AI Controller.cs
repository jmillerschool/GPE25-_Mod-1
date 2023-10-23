using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Guard, Chase, Attack };
    public AIState currentState;
    public GameObject target;

    private float lastStateChangeTime;
    
    
    // Start is called before the first frame update
    public override void Start()
    {
        ChangeState(AIState.Chase);
        
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
       
        // Run the parent (Base) update
        base.Update();
    }
    //Going to be recponsible for making AI Decisions
    public override void ProcessInputs()
    {
        switch (currentState)
        {
            case AIState.Guard:
                //Do work for guard
                DoGuardState();
                // Check for transiton
                if(IsDistanceLestThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            
            case AIState.Chase:
                // Do work for chase
                DoChaseState();
                //Check for transitions
                if(!IsDistanceLestThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                }
                break;           
        }
    }

    protected void DoGuardState()
    {
        // Doing gaurd state
        Debug.Log("Gaurding");
    }

    protected void DoChaseState()
    {
        //Doing chase State
        Debug.Log(" Chaseing");
        Seek(target);
    }

    

    public void Seek (GameObject target)
    {
        //RotateTowards the target
        pawn.RotateTowards(target.transform.position);
        // Move forward toward the target
        pawn.MoveForward();
        
    }
    public void Seek(Transform targetTransform)
    {
        // seek ther position of our target Transform
        Seek(targetTransform.position);
        
    }
    public void Seek(Vector3 targetPosition)
    {
        //RotateTowards the Function
        pawn.RotateTowards(targetPosition);
        //Move forward
        pawn.MoveForward();
    }

    public void Seek(Pawn targetPawn)
    {
        // Seek the pawns transform
        Seek(targetPawn.transform);
    }

    protected bool IsDistanceLestThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void ChangeState(AIState newState)
    {
        // Change the current state
        currentState = newState;

        // Save the time when we change states
        lastStateChangeTime = Time.time;
    }
    
}
