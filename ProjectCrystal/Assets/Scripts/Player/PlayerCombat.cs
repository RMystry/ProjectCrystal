using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;

    Vector2 attackPointPos;
    Vector2 attackPointDir;

    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage;

    public int dirStrength = 10;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackPointPos = attackPoint.position;
        
        attackPointDir.x = 0;
        attackPointDir.y = 0;

        if (Input.GetKey("up"))
        {
            attackPointDir.y = 1;
        }
        else if (Input.GetKey("down"))
        {
            attackPointDir.y = -1;
        }

        if (Input.GetKey("left"))
        {
            attackPointDir.x = -1;
        }
        else if (Input.GetKey("right"))
        {
            attackPointDir.x = 1;
        }
        
        //attackPointDir.x = Input.GetAxisRaw("Horizontal");
        //attackPointDir.y = Input.GetAxisRaw("Vertical");

       

        if (Input.GetMouseButtonDown(0))
        {
            if (attackPointDir.x != 0 || attackPointDir.y != 0)
            {
                attackPoint.position.Set(attackPoint.position.x + (attackPointDir.x * dirStrength), attackPoint.position.y + (attackPointDir.y * dirStrength), 0);
            }
            Debug.Log("Attacking...");
            attack();
        }

    }

    void attack()
    {

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  
    }
}





