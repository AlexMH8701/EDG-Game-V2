using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform LightAttack;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        //play animation

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LightAttack.position, attackRange, enemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(20);
            Debug.Log("Hit" + enemy.name);
        }

    }


    void OnDrawGizmosSelected()
    {
        //draws it so we can see it in scene editor
        if (LightAttack == null)
            return;

        Gizmos.DrawWireSphere(LightAttack.position, attackRange);
    }


}
