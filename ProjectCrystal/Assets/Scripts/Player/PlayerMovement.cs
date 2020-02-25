using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;
    public int delay;
    Vector2 movement;
    public int dashSpeed = 25;
    public double stamina = 100f;

    private int staminaTimeDelay = 100;

    public Text staminaText;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        //Check Dash
        if (Input.GetKeyDown("left shift") && stamina >= 10)
        {
            if (stamina > 0)
            {
                stamina -= 10;
                delay = 100; //Delay before stamina starts to recharge
            }

            movement.x *= dashSpeed;

            movement.y *= dashSpeed;

        }

        if (delay > 0)
        {
            //Decrement delay
            delay--;
        }
        else if (stamina < 100 && staminaTimeDelay == 0) //Check if Stamina has been used and needs recharging
        {
            stamina++;
            staminaTimeDelay = 10;
        }

        if(staminaTimeDelay > 0)
        {
            staminaTimeDelay--;
        }

        staminaText.text = "Stamina: " + stamina.ToString();

        //Check which movement animation needs to be played.
        switch(movement.x)
        {
            case 1: 
                animator.SetTrigger("Right");
                break;
            case -1:
                animator.SetTrigger("Left");
                break;
            default:
                switch(movement.y)
                {
                    case 1:
                        animator.SetTrigger("Up");
                        break;
                    case -1:
                        animator.SetTrigger("Down");
                        break;
                    default:
                        animator.SetTrigger("Idle");
                        break;
                }
                break;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
