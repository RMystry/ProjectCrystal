using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler1 :  Enemy
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2;
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
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    public void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }
}

