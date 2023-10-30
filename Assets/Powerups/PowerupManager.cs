using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;

    private List<Powerup> removedPowerupQueue;

    public void DecrementPowerupTimer()
    {
        // One at a time put each object in "powerups" into the variable "powerups" and do the loop body on it
        foreach (Powerup powerup in powerups)
        {
            if (!powerup.isPermanent)
            {
                // Subtract the time it took to draw the frame from the duration
                  powerup.duration -= Time.deltaTime;

                 // If time is up we want to remove this powerup
                if (powerup.duration <= 0)
                {
                     Remove(powerup );
                }

            }
            
            
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();

        // Add new list
        removedPowerupQueue = new List<Powerup>();  
    }

    
    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimer();
       
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    private void LateUpdate()
    {
        ApplyRemovePowerupQueue();
    }




    // The add function will add a powerup
    public void Add(Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);

        // Save it to the list
        powerups.Add(powerupToAdd);
    }
   
    //The Remove function will  add a powerup
    public void Remove(Powerup powerupToRemove)
    {
        // Remove the powerup
        powerupToRemove.Remove(this);

        // Add it to the "to be removed queue"
        removedPowerupQueue.Add(powerupToRemove);
    }

    private void ApplyRemovePowerupQueue()
    {
        // Now that we are sure we are not iterating through "powerups" remove the powerup that are in our temporary list
        foreach (Powerup powerup in removedPowerupQueue)
        {
            powerups.Remove(powerup);
        }
        // and reset our temporary list
        removedPowerupQueue.Clear();
    }

}
