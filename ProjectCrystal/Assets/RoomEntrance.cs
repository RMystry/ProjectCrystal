using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntrance : MonoBehaviour
{
    CameraAdjust camera;
    // Start is called before the first frame update
    void Start()
    {
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
            camera.ChangeSize(7.8f);
        }
    }
}
