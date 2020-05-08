using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{

    public float defaultSize = 5.5f;
    public float size;
    public float xPos;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = defaultSize;
        //Camera.main.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Scales camera to size and moves to position (x , y)
    public void ChangeSize(float size, Vector3 pos)
    {
        //Size can only contain 1 decimal point at most
        //this.size = size;
        //xPos = x;
        //yPos = y;

        //Discard this later if we want better Camera movement. For now camera just teleports to location.
        Camera.main.orthographicSize = size;
        Camera.main.transform.position = pos;

        //StartCoroutine("Scale");
        //StartCoroutine("Move");
    }

    //Scales camera to proper size
    IEnumerator Scale()
    {
        while (Camera.main.orthographicSize != size)
        {
            if(Camera.main.orthographicSize < size)
            {
                Camera.main.orthographicSize += .1f;
            }
            else if(Camera.main.orthographicSize > size)
            {
                Camera.main.orthographicSize -= .1f;
            }
            yield return null;
        }
        
    }

    //Moves camera to proper position
    IEnumerator Move()
    {
        float tempX = Camera.main.transform.position.x;
        float tempY = Camera.main.transform.position.y;
        while (Camera.main.transform.position.x != xPos)
        {
            
            if(Camera.main.transform.position.x < xPos)
            {   
                tempX += .1f;
            }
            else if(Camera.main.transform.position.x > xPos)
            {
                tempX -= .1f;
            }

            if (Camera.main.transform.position.y < yPos)
            {
                tempY += .1f;
            }
            else if (Camera.main.transform.position.y > yPos)
            {
                tempY -= .1f;
            }

            //Move Camera a small amount every frame. Give illusions of animation.
            Camera.main.transform.position.Set(tempX, tempY, -10);
            yield return null;
        }
        
    }
}
