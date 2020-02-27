using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public GameObject bullet;
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        
    }
}
