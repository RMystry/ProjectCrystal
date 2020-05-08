using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;
    protected Transform Player;
    public HealthBar healthBar;
    public SpriteRenderer renderer;
    protected Counter counter;
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        counter = GameObject.Find("Counter").GetComponent<Counter>();
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
        StartCoroutine("Flash");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            die();
        }
    }
    public void die()
    {
        counter.numOfEnemies--;
        Debug.Log("Number of Enemies: " + counter.getNumOfEnemies());
        //Debug.Log("Enemy Died");
        Destroy(gameObject);
        
        //Die Animation
        //Disable Enemy
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 10; i++)
        {
            renderer.color = Color.red;
            yield return null;
        }
        renderer.color = Color.white;
    }

}
