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
    
    // Start is called before the first frame update
    void Start()
    {
        roomSize = new float[10];
        
        //Set room size values
        roomSize[0] = 5.6f;
        roomSize[1] = 7.8f;

        roomPos = new Vector3[10];

        //Set room position values
        roomPos[0] = new Vector3(0, 0, -10);
        roomPos[1] = new Vector3(0, 12, -10);
        
        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraAdjust>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            camera.ChangeSize(roomSize[1], roomPos[1]);
        }
    }
}
