using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : MonoBehaviour
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
       // Variable to store other object powerupcontroller if it has one
       PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupContoller
        if (powerupManager != null )
        {
            // add the powerup
            powerupManager.Add(powerup);

            // destroy this pickup
            Destroy(gameObject);
        }
    }
}
