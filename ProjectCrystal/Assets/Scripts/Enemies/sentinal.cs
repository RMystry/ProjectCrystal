using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentinal : Enemy
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public int shootDelay = 0;
    public GameObject bullet;
    public Transform firePoint;
    public bool shooting = false;
    int burst = 3;
    int burstDelay;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
        if(shooting)
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
       
        if(shootDelay <= 0)
        {
            shooting = true;
        }
        else
        {
            shootDelay--;
        }
        
        
    }

    private void Shoot()
    {
        if (shootDelay <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);

            burstDelay = 40;
            burst--;
        }
        else
        {
            burstDelay--;
        }


    }
}
