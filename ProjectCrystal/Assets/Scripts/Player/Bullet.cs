using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public float bulletTime = 1;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
  
        rb.velocity = transform.right * speed; //Need to fix this so that bullet speed accounts for player speed
    }

    void Update()
    {
        bulletTime -= Time.deltaTime;
        if(bulletTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.takeDamage(damage);
        }
        
        if(hitInfo.name != "Player" && hitInfo.tag != "Player")
        {
            //Debug.Log("BULLET DESTROYED");
            Destroy(gameObject);
        }
        
    }
}
