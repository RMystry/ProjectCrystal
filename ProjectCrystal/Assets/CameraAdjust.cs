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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSize(float size)
    {
        //Size can only contain 1 decimal point at most
        this.size = size;
        StartCoroutine("Scale");
    }

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

    IEnumerator Move()
    {
        float tempX = Camera.main.transform.position.x;
        float tempY = Camera.main.transform.position.y;
        while (Camera.main.transform.position.x != xPos)
        {
            
            if(Camera.main.transform.position.x < xPos)
            {
                Camera.main.transform.position.Set(tempX, tempY, -10);
            }
            else if(Camera.main.transform.position.x > xPos)
            {

            }
        }
        yield return null;
    }
}
