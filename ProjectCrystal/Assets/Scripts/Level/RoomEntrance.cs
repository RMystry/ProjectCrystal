using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntrance : MonoBehaviour
{
    //Get an instance of the camera object
    CameraAdjust camera;

    //An array to hold camera size values for each room. This is so the Camera can scale correctly to a pre-set value
    float[] roomSize;

    //An array to hold camera position values for each room. This is so the Camera can move to the proper room position.
    Vector3[] roomPos;

    int num;

    int currentRoom;

    bool[] roomCleared;

    GameObject player;

    Counter counter;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        roomSize = new float[20];
        
        //Set room size values
        roomSize[0] = 5.6f;
        roomSize[1] = 6f;
        roomSize[2] = 6.6f;
        roomSize[3] = 6.6f;
        roomSize[4] = 6.6f;
        roomSize[5] = 5.4f;
        roomSize[6] = 5.4f;
        roomSize[7] = 4.8f;
        roomSize[8] = 4.8f;
        roomSize[9] = 5.4f;
        roomSize[10] = 5.4f;
        roomSize[11] = 7.2f;
        roomSize[12] = 5.4f;
        roomSize[13] = 3.9f;
        roomSize[14] = 3.9f;
        roomSize[15] = 3.9f;
        roomSize[16] = 5.4f;
        roomSize[17] = 5.4f;
        roomSize[18] = 6.6f;


        roomPos = new Vector3[20];

        //Set room position values
        roomPos[0] = new Vector3(0, 0, -10);
        roomPos[1] = new Vector3(0, 12, -10);
        roomPos[2] = new Vector3(-24.42f, 13.55f, -10);
        roomPos[3] = new Vector3(24.42f, 13.55f, -10);
        roomPos[4] = new Vector3(0, 24.85f, -10);
        roomPos[5] = new Vector3(-23.79f, 26.61f, -10);
        roomPos[6] = new Vector3(23.79f, 26.61f, -10);
        roomPos[7] = new Vector3(-22.96f, 34.79f, -10);
        roomPos[8] = new Vector3(22.96f, 34.79f, -10);
        roomPos[9] = new Vector3(-20.87f, 46.32f, -10);
        roomPos[10] = new Vector3(1.2f, 46.4f, -10);
        roomPos[11] = new Vector3(25.1f, 48.1f, -10);
        roomPos[12] = new Vector3(23.65f, 59.8f, -10);
        roomPos[13] = new Vector3(-14.3f, 66.65f, -10);
        roomPos[14] = new Vector3(1.2f, 66.65f, -10);
        roomPos[15] = new Vector3(21.2f, 66.65f, -10);
        roomPos[16] = new Vector3(-20.87f, 55.7f, -10);
        roomPos[17] = new Vector3(1.2f, 57f, -10);
        roomPos[18] = new Vector3(0, 34.31f, -10);

        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraAdjust>();

        num = int.Parse(gameObject.tag);

        roomCleared = new bool[20];

        for(int i = 0; i < roomCleared.Length; i++)
        {
            roomCleared[i] = false;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        currentRoom = counter.getCurrentRoom();
        //Debug.Log("Current Room: " + currentRoom);
        if (currentRoom == 4 || currentRoom == 18)
        {
            if (player.transform.position.y >= 24.85 && player.transform.position.y <= 34.31)
            {
                Vector3 playerPos = new Vector3(camera.transform.position.x, player.transform.position.y, -10);
                Camera.main.transform.position = playerPos;
            }

        }
        else if (currentRoom == 9 || currentRoom == 16)
        {
            if (player.transform.position.y >= 46.32 && player.transform.position.y <= 55.7)
            {
                Vector3 playerPos = new Vector3(camera.transform.position.x, player.transform.position.y, -10);
                Camera.main.transform.position = playerPos;
            }
        }
        else if (currentRoom == 10 || currentRoom == 17)
        {
            if (player.transform.position.y >= 46.4 && player.transform.position.y <= 57)
            {
                Vector3 playerPos = new Vector3(camera.transform.position.x, player.transform.position.y, -10);
                Camera.main.transform.position = playerPos;
            }
        }
        
        if(currentRoom == 13 || currentRoom == 14 || currentRoom == 15)
        {
            //Debug.Log("HIT");
            if (player.transform.position.x >= -14.53 && player.transform.position.x <= 21.31)
            {
                Vector3 playerPos = new Vector3(player.transform.position.x, camera.transform.position.y, -10);
                Camera.main.transform.position = playerPos;
            }
        }
        

        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            camera.ChangeSize(roomSize[num], roomPos[num]);
            counter.setCurrentRoom(num);
        }
    }
}
