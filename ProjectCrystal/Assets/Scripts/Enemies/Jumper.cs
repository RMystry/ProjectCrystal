using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : Enemy
{
    public float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private readonly float timer = 2f;
    public float puase = 0f;
    public bool changedDir = true;
    public Animator animator;
    private int damage = 10;
    private Vector2 movement;
    private Rigidbody2D rb;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        latestDirectionChangeTime = Random.Range(0, 5);
        currentHealth = maxHealth;
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        rb = this.GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        rb = this.GetComponent<Rigidbody2D>();

        if (Time.time - latestDirectionChangeTime > directionChangeTime && !changedDir)
        {
            puase = Time.time;
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
            changedDir = true;
        }
        else if (Time.time - puase > timer)
        {
            latestDirectionChangeTime = Time.time;
            puase = Time.time;
            changedDir = false;
        }
    }
    private void FixedUpdate()
    {
        if (changedDir)
        {

            MoveCharacter(movement);
        }
    }
    public void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        //Debug.Log("HIT");
        //Debug.Log(hitInfo.gameObject.tag);
        if (hitInfo.gameObject.tag.Equals("Player"))
        {
            PlayerCombat player = hitInfo.gameObject.GetComponent<PlayerCombat>();
            player.takeDamage(damage);
        }
        else if (hitInfo.gameObject.tag.Equals("Enemy"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), hitInfo.gameObject.GetComponent<Collider2D>(), true);
        }
    }
}