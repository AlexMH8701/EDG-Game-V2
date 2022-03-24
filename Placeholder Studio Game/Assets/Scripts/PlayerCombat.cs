using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform LightAttack;

    public Transform HeavyAttack;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    //checks to see if we need P1 or P2 controls
    public bool player1;

     //The interval you want your player to be able to fire.
    float AttackRate  = 0.5f;
 
    //The actual time the player will be able to fire.
     private float NextAttack;

    public PauseMenu PauseMenu;
   

    // Update is called once per framevoid Update()
	 void Update()
     {

         //makes sure the game is not paused before letting them attack
         if (PauseMenu.GameIsPaused){
            return;
        }

		if (((Input.GetKeyDown(KeyCode.Q) && player1) || (Input.GetKeyDown(KeyCode.O) && !player1)) && Time.time > NextAttack)
		{

             bool canDmg = gameObject.GetComponent<Health>().canDmg;

			if (canDmg) {

				Invoke("LAttack", 0.05f);
                NextAttack = Time.time + AttackRate;
			}

		}

        if (((Input.GetKeyDown(KeyCode.E) && player1) || (Input.GetKeyDown(KeyCode.U) && !player1)) && Time.time > NextAttack)
		{

             bool canDmg = gameObject.GetComponent<Health>().canDmg;

			if (canDmg) {
				Invoke("HAttack", 0.1f);
                NextAttack = Time.time + AttackRate*3;
			}

		}
	}

    //light attack
	 void LAttack()
    {

		//play animation

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LightAttack.position, attackRange*1.5f, enemyLayer);


        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(20);
			Debug.Log("Light Attack Hit " + enemy.name);
        }


    }

    //heavy attack
    void HAttack()
    {

		//play animation

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(HeavyAttack.position, attackRange, enemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(40);
			Debug.Log("Heavy Attack Hit " + enemy.name);
        }

    }

	void OnDrawGizmosSelected()
    {
        //draws attack so we can see it in scene editor
        if (LightAttack == null)
            return;
        if (HeavyAttack == null)
        Gizmos.DrawWireSphere(HeavyAttack.position, attackRange);
    }
}