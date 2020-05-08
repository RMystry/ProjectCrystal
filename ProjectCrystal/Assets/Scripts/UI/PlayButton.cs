using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Sprite originalTexture;
    public Sprite newTexture;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = newTexture;
        Debug.Log("switch texture!");
    }
    void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer> ().sprite = originalTexture;
        Debug.Log("switch texture!");
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("switch scene!");
    }
}
