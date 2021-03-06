﻿using System.Collections;
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
    IEnumerator coroutine;
    AudioSource bossMusic;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
        Crystal = GameObject.Find("Crystal");
        counter = GameObject.FindObjectOfType<Counter>();
        animator = Crystal.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        bossMusic = this.GetComponent<AudioSource>();
        touched = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(touched == 0)
        {
            touched = 1;
            coroutine = FadeOut(Camera.main.GetComponent<AudioSource>());
            StartCoroutine(coroutine);
            
            //crystalCamera = true;
            //StartCoroutine("floatUp");
            StartCoroutine("Wait");
            
        }

        //All enemies are dead
        if(counter.bossRoomActive)
        {
            if (counter.getNumOfEnemies() == 0)
            {
                counter.bossRoomActive = false;
                if (counter.waveCounter == 1)
                {
                    counter.waveCounter = 2;
                    animator.SetTrigger("Idle 2");
                    StartCoroutine("WaitLonger");
                }
                else if (counter.waveCounter == 2)
                {
                    counter.waveCounter = 3;
                    animator.SetTrigger("Idle 3");
                    StartCoroutine("WaitLonger");
                }
                else
                {
                    coroutine = FadeOut(bossMusic);
                }
            }
        }
        
    }

    void StartWave()
    {
        
        if (counter.waveCounter == 1)
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

        counter.bossRoomActive = true;
    }

    IEnumerator floatUp()
    {
        for(int i = 0; i < 120; i++)
        {
            //Debug.Log("CRYSTAL MOVE");
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
        bossMusic.Play();
    }

    IEnumerator WaitLonger()
    {
        Debug.Log("hit 1");
        yield return new WaitForSeconds(10);
        //crystalCamera = false;
        StartWave();
    }

    IEnumerator FadeOut(AudioSource source)
    {
        while(source.volume > 0)
        {
            source.volume = source.volume - 0.001f;
            yield return null;
        }
        source.Stop();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            touched++;
        }
        
    }
}
