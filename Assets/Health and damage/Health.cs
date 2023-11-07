using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public float maxHealth;

    // amount of score for death
    public float deathScore;

    //UI variable
    public Image fillAmount;

    public void Die (Pawn source)
    {
        Debug.Log(" You Died ");

        Destroy(gameObject);
    }

    public void TakeDamage (float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        
        if (currentHealth <= 0)
        {
            Die (source);
        }
        
    }
     
    public void Heal (float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        Debug.Log(source.name + " Healed " + amount + " points to " + gameObject.name);
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
       
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // set Health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
