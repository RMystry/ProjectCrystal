using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentinal : Enemy
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public int shootDelay;
    public GameObject bullet;
    private Transform firePoint;
    public bool shooting = false;
    int burst = 3;
    int burstDelay;
    int randomDelay;
    int randDelay;
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        firePoint = gameObject.transform.Find("SentryShootPoint");
        rb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        randDelay = Random.Range(1, 75);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > -45f && angle < 45)
        {
            animator.SetTrigger("Right");
        }
        else if (angle > 45 && angle < 135)
        {
            animator.SetTrigger("Up");
        }
        else if (angle > 135 || angle < -135)
        {
            animator.SetTrigger("Left");
        }
        else
        {
            animator.SetTrigger("Down");
        }
        //Debug.Log("Angle is: " + angle);
        /*rb.rotation = angle;
        direction.Normalize();
        movement = direction;*/
    }

    void FixedUpdate()
    {
        if (randDelay <= 0)
        {
            if (shooting)
            {
                if (burst > 0)
                {
                    Shoot();
                }
                else
                {
                    shooting = false;
                    burst = 3;
                    shootDelay = 75;
                }
            }

            if (shootDelay <= 0)
            {
                shooting = true;
            }
            else
            {
                shootDelay--;
            }
        }
        else
        {
            randDelay--;
        }
        
        
    }

    private void Shoot()
    {
        if (burstDelay <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);

            burstDelay = 10;
            burst--;
        }
        else
        {
            burstDelay--;
        }


    }
}
