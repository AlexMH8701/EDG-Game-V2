using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public AudioSource Lattacksound;
     public AudioSource Hattacksound;
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
    public Animator animator;


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

                Lattacksound.Play();
                animator.SetTrigger("LightAttack");
				StartCoroutine(LAttack());
			}

            NextAttack = Time.time + AttackRate;

		}

        if (((Input.GetKeyDown(KeyCode.E) && player1) || (Input.GetKeyDown(KeyCode.U) && !player1)) && Time.time > NextAttack)
		{
             Hattacksound.Play();
             bool canDmg = gameObject.GetComponent<Health>().canDmg;

			if (canDmg) {
                animator.SetTrigger("HeavyAttack");
				StartCoroutine(HAttack());
			}

            NextAttack = Time.time + AttackRate*3;

		}
	}

    IEnumerator LAttack(){

        float time = .1f;

        yield return new WaitForSeconds(time);

        while(time < 1.5f){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LightAttack.position, attackRange, enemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<Health>().canDmg){
                enemy.GetComponent<Health>().TakeDamage(20);
                time = 2;
            }
            yield return new WaitForSeconds(.2f);
            
        }
        time += .2f;
        }
    }

    //heavy attack
    IEnumerator HAttack(){

        float time = .2f;

        yield return new WaitForSeconds(time);

        while(time < 1.5f){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LightAttack.position, attackRange, enemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<Health>().canDmg){
                enemy.GetComponent<Health>().TakeDamage(40);
                time = 2;
            }
            yield return new WaitForSeconds(.2f);
            
        }
        time += .2f;
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
