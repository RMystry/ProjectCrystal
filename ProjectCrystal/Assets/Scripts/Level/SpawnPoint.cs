using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Crawler1 crawler;
    public sentinal sentry;
    public Jumper jumper;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        //Create random integer to determine what enemy to spawn
        int random = (int) (Random.Range(1, 3) + .5f);

        switch(random)
        {
            case 1:
                Instantiate(crawler, this.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(sentry, this.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(jumper, this.transform.position, Quaternion.identity);
                break;
            default:
                break;

        }
    }
}
