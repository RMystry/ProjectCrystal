using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;
    public Transform Player;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setHealth(int s)
    {
        maxHealth = s;
    }
    public void takeDamage(int damage)
    {
        //Damage Animation

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
    }
    public void die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
        //Die Animation
        //Disable Enemy
    }

}
