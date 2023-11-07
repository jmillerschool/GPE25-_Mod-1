using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class ScorePowerup : Powerup
{
    public float scoreToAdd;
    public override void Apply(PowerupManager target)
    {
        // Apply score changes
        Pawn pawn = target.GetComponent<Pawn>();

        if (pawn != null)
        {
            pawn.controller.AddToScore(scoreToAdd);
        }
        
    }

    public override void Remove(PowerupManager target)
    {
        // Not Needed

    }
}
