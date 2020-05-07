using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler1 :  Enemy
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2;
    public Animator animator;
    public int damage = 10;
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        rb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;

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
    }
    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    public void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log("HIT");
        Debug.Log(hitInfo.gameObject.tag);
        if (hitInfo.gameObject.tag.Equals("Player"))
        {
            PlayerCombat player = hitInfo.gameObject.GetComponent<PlayerCombat>();
            player.takeDamage(damage);
        }
    }
}

