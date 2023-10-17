using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    
    // Start is called before the first frame update
    public void Start()
    {
        GameObject newObject = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        Debug.Log(newObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
