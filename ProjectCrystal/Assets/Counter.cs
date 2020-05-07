using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    int currentRoom;
    int numOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = 0;
        numOfEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCurrentRoom()
    {
        return currentRoom;
    }

    public void setCurrentRoom(int num)
    {
        currentRoom = num;
    }

    public void setNumOfEnemies(int num)
    {
        numOfEnemies = num;
    }

    public int getNumOfEnemies()
    {
        return numOfEnemies;
    }
}
