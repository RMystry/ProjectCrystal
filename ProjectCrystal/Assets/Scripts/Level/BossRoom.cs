using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    SpawnPoint[] spawnPoints;
    int touched;
    bool crystalCamera;
    GameObject animation;
    GameObject Crystal;
    Counter counter;
    Animator animator;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
        Crystal = GameObject.Find("Crystal");
        counter = GameObject.FindObjectOfType<Counter>();
        animator = Crystal.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        touched = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(touched == 0)
        {
            touched = 1;
            //crystalCamera = true;
            //StartCoroutine("floatUp");
            StartCoroutine("Wait");
        }

        //All enemies are dead
        if(counter.getNumOfEnemies() == 0)
        {
            if(counter.waveCounter == 1)
            {
                counter.waveCounter = 2;
                animator.SetTrigger("Idle 2");
                StartCoroutine("WaitLonger");
            }
            else if(counter.waveCounter == 2)
            {
                counter.waveCounter = 3;
                animator.SetTrigger("Idle 3");
                StartCoroutine("WaitLonger");
            }
        }
    }

    void StartWave()
    {
        if(counter.waveCounter == 1)
        {
            //Debug.Log("hit 1");
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                if (spawnPoint.tag == "Wave 1")
                {
                    spawnPoint.SpawnEnemy();
                }
            }
        }
        else if (counter.waveCounter == 2)
        {
            Debug.Log("hit 2");
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                if (spawnPoint.tag == "Wave 1" || spawnPoint.tag == "Wave 2")
                {
                    spawnPoint.SpawnEnemy();
                }
            }
        }
        else if(counter.waveCounter == 3)
        {
            Debug.Log("hit 3");
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                if (spawnPoint.tag == "Wave 1" || spawnPoint.tag == "Wave 2" || spawnPoint.tag == "Wave 3")
                {
                    spawnPoint.SpawnEnemy();
                }
            }
        }
        
        
    }

    IEnumerator floatUp()
    {
        for(int i = 0; i < 120; i++)
        {
            Debug.Log("CRYSTAL MOVE");
            Crystal.transform.position = new Vector3(Crystal.transform.position.x, Crystal.transform.position.y + .0005f, Crystal.transform.position.z);
            yield return null;
        }
        yield return new WaitForSeconds(5);
        crystalCamera = false;
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        //crystalCamera = false;
        StartWave();
    }

    IEnumerator WaitLonger()
    {
        Debug.Log("hit 1");
        yield return new WaitForSeconds(10);
        //crystalCamera = false;
        StartWave();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            touched++;
        }
        
    }
}
