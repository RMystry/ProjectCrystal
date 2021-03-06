﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    int currentRoom;
    public int numOfEnemies;
    bool[] roomCleared;
    public bool roomActive;
    public int waveCounter;
    public bool bossRoomActive;
    // Start is called before the first frame update
    void Start()
    {
        roomCleared = new bool[20];
        currentRoom = 0;

        for (int i = 0; i < roomCleared.Length; i++)
        {
            roomCleared[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("numEnemies: " + numOfEnemies);
        

       if(numOfEnemies > 0)
        {
            //Set active variable so we know to check for when the last enemy is killed
            roomActive = true;
        }

       if(roomActive)
        {
            //Check for when last enemy is killed
            if(numOfEnemies == 0 && currentRoom != 19)
            {
                //Mark room as cleared
                roomCleared[currentRoom] = true;
                Debug.Log("Room " + currentRoom + " Is Cleared");
                //Deactivate room
                roomActive = false;
            }
            else if(numOfEnemies == 0 && waveCounter < 4)
            {
                roomActive = false;
            }
        }
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

    public bool RoomCleared(int num)
    {
        return roomCleared[num];
    }
}
