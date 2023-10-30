using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    public KeyCode callGenerateMap;
    private Room[,] grid;
    public int mapSeed;
    public bool mapOfTheDay;
    public bool randomMap;

    // Start is called before the first frame update
    void Start()
    {
        if (mapOfTheDay)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
        else if (randomMap)
        {
            mapSeed = DateToInt(DateTime.Now);
        }

        UnityEngine.Random.InitState(mapSeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(callGenerateMap))
        {
            GenerateMap();
        }

    }

    // Returns a random room
    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }

    public int DateToInt ( DateTime dateToUse )
    {
        // Add our date up and retuen it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
    
    public void GenerateMap()
    {
        //set our seed
        UnityEngine.Random.InitState(mapSeed);

        // Clear out the grid - "column" is our X, "row" is our Y
        grid = new Room[cols, rows];

        //For each grid row...
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // for each column in that row
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                // Figure out the location
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                // Create a new grid at the appropriate location
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                // set its parent
                tempRoomObj.transform.parent = this.transform;

                // Give it a meaningful name
                tempRoomObj.name = "Room" + currentCol + "," + currentRow;

                // Get the room object 
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                // Save it to the grid array
                grid[currentCol, currentRow] = tempRoom;

                //Open the doors
                // If we are on the bottom row, open the north door
                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    //Otherwise if we are on the top row open the south door
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    //Otherwise we are in the middle, so open both doors
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }


                // If we are in the West column, open the West door
                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    // Otherwise if we are in the East column, open the East column
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    // Otherwise we are in the middle so open both doors
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }
        }


    }
            
}
    
       

