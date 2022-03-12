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
	private bool canDmg = true;
	private int lives = 3;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (canDmg) {
				TakeDamage(100);
			}
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
        {
			currentHealth = maxHealth;
			canDmg = false;
			removeLife();
			healthBar.SetMaxHealth(maxHealth);
			player.transform.position = respawnPoint.position;
			lives -= 1;
			StartCoroutine(RespawnProtection());
			player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
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
		yield return new WaitForSeconds(2);
		canDmg = true;
		yield return null;
	}
}