using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentCotroller : MonoBehaviour
{
    //Variable to hold our Pawn
    public ParentPawn pawn; 

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    //Our child classes MUST overfide the way the process inputs
    public abstract void ProcessInputs();
}
