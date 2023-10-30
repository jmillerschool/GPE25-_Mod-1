using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
        
    public float healthToAdd;
    public override void Apply(PowerupManager target)
    {
        // Apply health changes
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
           // the second parameter is the pawn who caused the healing - in this case healed themselves
           targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
    }
    public override void Remove(PowerupManager target)
    {
        // TO remove health changes
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.GetComponent <Pawn>());
        }

    }
}

