using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : Controller
{
    public enum AIState { Patrol, Guard, Chase, Attack, Flee };
    public AIState currentState;
    public GameObject target;
    public float fleeDistance;
    public Transform[] waypoint;
    public float waypointStopDistance;
    public float hearingDistance;
    public float fieldOfView;
    
    private int currentWaypoint = 0;
    private float lastStateChangeTime;

    public TankPawn tankPawn;
    
    
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

        if (tankPawn == null)
        {
            Destroy(this);
        }
    }
    //Going to be recponsible for making AI Decisions
    public override void ProcessInputs()
    {
        if (pawn == null)
        {
            Destroy(gameObject);
        }

        switch (currentState)
        {
            
            case AIState.Guard:
                //Do work for guard
                DoGuardState();
                // Check for transiton
                if(IsDistanceLestThan(target, 14))
                {
                    ChangeState(AIState.Chase);
                }
                
                break;
            
            case AIState.Chase:
                // Do work for chase
                // Could use IsCanSee and IsCanHear instead
                if(IsHasTarget())
                {
                    DoChaseState();
                }
                else
                {
                    TargetPlayerOne();
                }

                //Check for transitions
                if (IsDistanceLestThan(target,5))
                {
                    ChangeState(AIState.Attack);
                }

                if(!IsDistanceLestThan(target, 14))
                {
                    ChangeState(AIState.Guard);
                }
                break;

            case AIState.Attack:
                // Do work for Attack
                DoAttackState();
                if(!IsDistanceLestThan(target,5))
                {
                    ChangeState(AIState.Chase);
                }
                break;
                             
        }
    }

    protected void DoPatrolState()
    {
        // If we hace a enough waypoints in our list to move to a current waypoint
        if (waypoint.Length > currentWaypoint)
        {
            // Than seek out that waypoint
            Seek(waypoint[currentWaypoint]);
            
            // If we are close enough than increment to next waypoint
            if (Vector3.Distance(pawn.transform.position, waypoint[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }

    protected void RestartPatrol()
    {
        //Set the index to 0
        currentWaypoint = 0;
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

    protected void DoAttackState()
    {
        // Chase
        Seek(target);
        // Shoot
        Shoot();
    }

    protected void DoFleeState()
    {
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        Seek(pawn.transform.position + fleeVector);
        float targetDistance = Vector3.Distance( target.transform.position, pawn.transform.position );
        float percentOfFleeDistance = targetDistance / fleeDistance;
        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
        float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
    }

    public void Shoot()
    {
        pawn.Shoot();
    }

    // Seek Functons
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

    // Helpper Functions
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

    public void TargetPlayerOne()
    {
        // If the GameManager exist
        if (GameManager.instance != null)
        {
            //And the arre of player exist
            if (GameManager.instance.player != null)
            {

                // And there are players in it
                if (GameManager.instance.player.Count > 0)
                {
                    // Than target the gameObject of the pawn of the firs contoller in the list
                    target = GameManager.instance.player[0].pawn.gameObject;
                }
            }
        }
    }

    protected bool IsHasTarget()
    {
        // return true if we have a target - False if we dont
        return (target != null);
    }

    protected void TargetNearsetTank()
    {
        //Get a list of all the tanks (pawns)
        Pawn[] allTank = FindObjectsOfType<Pawn>();

        //Assume that the first tank is closet
        Pawn closestTank = allTank[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTank)
        {
            //If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                closestTank = tank;                
            }
        }

        //Target the closet tank
        target = closestTank.gameObject;

    }

    public bool IsCanHear(GameObject target)
    {
        // Get the target noisemaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();

        //if they dont have one they cant make noise so return false
        if (noiseMaker == null)
        {
            return false;
        }

        //if they are making 0 noise they also cant be heard
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }

        // IF they are making noise add the volumeDistance in the noisemaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        // if the distance between our pawn and target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            // ... than we can hear the target
            return true;
        }
        else
        {
            // Otherwise we are too far away to hear them
            return false;
        }        
    }
    protected bool IsCanSee(GameObject target)
    {
        // Find the vecto from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;

        // Find the angle between the direction our agent is facing (Forward if local space) and the vector to the target
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.position);
        Debug.Log(angleToTarget);
        
        //Fi that agle is less than our field of view
        if (angleToTarget < fieldOfView)
        {
            Debug.Log("In field of view!!!");
            return true;
        }
        else
        {
            return false;
        }
    }
}
