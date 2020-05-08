using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public float bulletTime = 1.5f;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    void Update()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("HIT");
        PlayerCombat player = hitInfo.GetComponent<PlayerCombat>();
        if (hitInfo.tag.Equals("Player"))
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }


    }
}
