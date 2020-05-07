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

    bool[] roomCleared;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        roomSize = new float[10];
        
        //Set room size values
        roomSize[0] = 5.6f;
        roomSize[1] = 6f;
        roomSize[2] = 6.6f;
        roomSize[3] = 6.6f;
        roomSize[4] = 6.6f;

        roomPos = new Vector3[10];

        //Set room position values
        roomPos[0] = new Vector3(0, 0, -10);
        roomPos[1] = new Vector3(0, 12, -10);
        roomPos[2] = new Vector3(-24.42f, 13.55f, -10);
        roomPos[3] = new Vector3(24.42f, 13.55f, -10);
        roomPos[4] = new Vector3(0, 24.85f, -10);
        
        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraAdjust>();

        num = int.Parse(gameObject.tag);

        roomCleared = new bool[12];

        for(int i = 0; i < roomCleared.Length; i++)
        {
            roomCleared[i] = false;
        }

        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
       
        if(num == 4)
        {
            if(player.transform.position.y >= 24.85 && player.transform.position.y <= 34.31)
            {
                Vector3 playerPos = new Vector3(camera.transform.position.x, player.transform.position.y, -10);
                Camera.main.transform.position = playerPos;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            camera.ChangeSize(roomSize[num], roomPos[num]);
        }
    }
}
