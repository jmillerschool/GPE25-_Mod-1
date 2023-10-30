using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    private float nextSpawnTime;
    public float spawnDelay;
    public Transform tf;
    private GameObject spawnedPickup;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If it is there is nothing spawns
        if (spawnedPickup == null)
        {
            // And  it is time to spawn
            if (Time.time > nextSpawnTime)
            {
                // Spawn it and set the next time
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // Otherwise the object still exists so postpone the spawn 
            nextSpawnTime = Time.time + spawnDelay;
        }               
        
    }
   
  
}
