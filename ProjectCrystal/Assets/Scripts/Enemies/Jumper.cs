using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : Enemy
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private readonly float timer = 1f;
    private float characterVelocity = 1f;
    private float puase = 0f;
    private bool changedDir = true;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator animator;
    private int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
        currentHealth = maxHealth;
    }
    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            puase = Time.time;
            changedDir = false;
        }
        if (Time.time - puase > timer)
        {
            latestDirectionChangeTime = Time.time;
            puase = Time.time;
            calcuateNewMovementVector();
            changedDir = true;
        }
    }
    private void FixedUpdate()
    {
        if (changedDir)
        {
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
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