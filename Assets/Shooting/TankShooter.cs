using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;
    
    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    { 
    }

    public override void Shoot(GameObject shellPrefab, float fireforce, float damageDone, float lifespan)
    {
        //Instantiate our pojectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        // Get the DamageOnHit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

        // IF it has one..
        if (doh != null )
        {
            // ... Set the damageDone ith the DamageOnHit component to ther value passed in
            doh.damageDone = damageDone;
             
            // ... Set the owner to the pawn that shot this shell, if there is one (otherwise, owner is null).
            doh.owner = GetComponent<Pawn>();
        }
        // Get the shells rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        // If it has one
        if (rb != null )
        {
            // ... AddForce to make it move forward
            rb.AddForce(firepointTransform.forward * fireforce);
        }

        // Destroy it after a set time
        Destroy(newShell, lifespan);
        
    }
}
