using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public GameObject bullet;
    public float speed = 10;
    public float charge = 30f;
    public float cooldown = 0;
    public int maxCharge = 30;
    public int delay = 10;
    public ChargeBar chargeBar;
    public int chargeDelay = 100;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && charge > 0)
        {
            chargeDelay = 200;
            if(cooldown == 0)
            {
                Shoot();
                chargeBar.SetCharge(charge);
            }
            
        }
        else if(Input.GetButtonDown("Fire1") && charge <=0 )
        {
            cooldown = 100;
        }
        else if(chargeDelay > 0)
        {
            chargeDelay--;
        }

        if(!(Input.GetButtonDown("Fire1")) && charge < maxCharge && delay <= 0)
        {
            if(chargeDelay <= 0)
            {
                charge++;
                chargeBar.SetCharge(charge);
                delay = 20;
            }
            
        }
        else if(delay > 0)
        {
            delay--;
        }

        if(cooldown > 0)
        {
            cooldown--;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        charge--;
    }
}
