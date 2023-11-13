using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        // Get the Health components from the Game Object that has the Collider that we are overlaping
        Health otherHealth = other.gameObject.GetComponent<Health>();
        
        //Only damage if it has a Health Component
        if (otherHealth != null)
        {
            // Do damamge
            otherHealth.TakeDamage(damageDone, owner);
        }

        // Destroy ourselfs, whether we did damage or not 
        Destroy(gameObject);
    }
}
