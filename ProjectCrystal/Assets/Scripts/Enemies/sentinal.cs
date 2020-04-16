using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentinal : Enemy
{
    private Rigidbody2D rb;
    private Vector2 movement;
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
}
