using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    
    public HealthPowerup powerup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Trigger Collider Info
    public void OnTriggerEnter(Collider other)
    {
        // Variable to store other objects powerupcontroller - if it has on 
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
       
        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            // add the powerup
            powerupManager.Add(powerup);

            // destroy this pickup
            Destroy(gameObject);
        }
    }
}
