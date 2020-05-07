using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public StaminaBar staminaBar;

    public float moveSpeed;
    public int delay;
    Vector2 movement;
    public int dashSpeed = 25;
    public float stamina = 100f;

    //private int staminaTimeDelay = 100;

    //public Text staminaText;

    public Animator animator;

    public bool isMoving = true;

    // Update is called once per frame
    void Update()
    {
        
        
        //movement.x = Input.GetAxisRaw("Horizontal");

        //movement.y = Input.GetAxisRaw("Vertical");

        //Check Dash
        if (Input.GetKeyDown("left shift") && stamina >= 10)
        {
            if (stamina > 0)
            {
                stamina -= 33;
                staminaBar.SetStamina(stamina);
                delay = 300; //Delay before extra speed runs out
                moveSpeed = 10f;
            }

        }

        if (delay > 0)
        {
            //Decrement delay
            delay--;
        }
        else
        {
            moveSpeed = 6f;
        }
        /*
        else if (stamina < 100 && staminaTimeDelay == 0) //Check if Stamina has been used and needs recharging
        {
            stamina++;
            staminaBar.SetStamina(stamina);
            staminaTimeDelay = 10;
        }

        if (staminaTimeDelay > 0)
        {
            staminaTimeDelay--;
        }*/

        switch (movement.x)
        {
            case 1:
                animator.SetTrigger("Right");
                isMoving = true;
                break;
            case -1:
                animator.SetTrigger("Left");
                isMoving = true;
                break;
            default:
                switch (movement.y)
                {
                    case 1:
                        animator.SetTrigger("Up");
                        isMoving = true;
                        break;
                    case -1:
                        animator.SetTrigger("Down");
                        isMoving = true;
                        break;
                    default:
                        animator.SetTrigger("Idle");
                        isMoving = false;
                        break;
                }
                break;
        }

    }

    void FixedUpdate()
    {
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey("w"))
        {
            movement.y = 1;
        }
        else if (Input.GetKey("s"))
        {
            movement.y = -1;
        }

        if (Input.GetKey("a"))
        {
            movement.x = -1;
        }
        else if (Input.GetKey("d"))
        {
            movement.x = 1;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //staminaText.text = "Stamina: " + stamina.ToString();

        //Check which movement animation needs to be played.

       

        
    }
    
}
