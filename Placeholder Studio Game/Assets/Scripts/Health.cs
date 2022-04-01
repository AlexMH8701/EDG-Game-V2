using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public Transform respawnPoint;
	public GameObject player;
	public bool canDmg = true;
	private int lives = 3;
	public Animator _animator;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	

	public void TakeDamage(int damage)
	{
		StartCoroutine(playHurtAnim());
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
        {
			currentHealth = maxHealth;
			canDmg = false;
			removeLife();
			healthBar.SetMaxHealth(maxHealth);
			lives -= 1;
			newRound();
        }
	}
	void newRound(){
		_animator.SetBool("hurt", false);
		player.transform.position = respawnPoint.position;
		StartCoroutine(RespawnProtection());
		player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	}
	void removeLife() {
		if (lives <= 0) {
			healthBar.SetMaxHealth(0);
			Destroy(this.gameObject);
			healthBar.removeHeath();
		} else {
			healthBar.removeHeath();
		}
	}
	IEnumerator RespawnProtection() {
		_animator.SetBool("spawn", true);
		yield return new WaitForSeconds(2);
		_animator.SetBool("spawn", false);
		canDmg = true;
	}

	IEnumerator playHurtAnim() {
		_animator.SetBool("hurt", true);
		yield return new WaitForSeconds(.2f);
		_animator.SetBool("hurt", false);
	}
}