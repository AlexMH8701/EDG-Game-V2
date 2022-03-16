using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform LightAttack;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    //checks to see if we need P1 or P2 controls
    public bool player1;


   

    // Update is called once per framevoid Update()
	 void Update()
     {
		if ((Input.GetKeyDown(KeyCode.Q) && player1) || (Input.GetKeyDown(KeyCode.O) && !player1))
		{

             bool canDmg = gameObject.GetComponent<Health>().canDmg;

			if (canDmg) {
				Attack();
			}
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
        //draws attack so we can see it in scene editor
        if (LightAttack == null)
            return;

        Gizmos.DrawWireSphere(LightAttack.position, attackRange);
    }
}