using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public float hp;
	public float maxHp = 100f;
	public HealthBar healthBar;
	bool canHit;
	bool healing;
	GameObject main;

	void Start()
	{
		hp = maxHp;
		healthBar.SetSize(hp / maxHp);
		canHit = true;
		healing = false;
		main = transform.parent.gameObject;
	}

	void Regenerate()
	{
		float health = hp + 5;
		if (health >= maxHp)
		{
			hp = maxHp;
		}
		else
		{
			hp = health;
		}
		float currentHp = hp / maxHp;
		healthBar.SetSize(currentHp);
	}
	IEnumerator HealDelay()
	{
		for (int i = 0; i < 20; i++)
		{
			yield return new WaitForSeconds(0.4f);
			Regenerate();
		}
		canHit = true;
		healing = false;
		transform.parent.position = new Vector3(0, 0, 0);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		main.GetComponent<playerMovement>().canMove = true;

		StartCoroutine(Flicker());
	}
	public void Heal()
	{
		hp = maxHp;
		float currentHp = hp / maxHp;
		healthBar.SetSize(currentHp);
	}
	void Die()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		main.GetComponent<playerMovement>().canMove = false;
	}
	void Respawn()
	{
		healing = true;
		canHit = false;
		Die();
		StartCoroutine(HealDelay());
	}
	IEnumerator Flicker()
	{
		bool off = false;
		for (int i = 0; i < 6; i++)
		{
			yield return new WaitForSeconds(0.05f);
			if (off == true)
			{
				off = false;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
			else
			{
				off = true;
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
		}
		if (healing == true)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}

	}
	public void TakeDamage(float damage)
	{
		hp -= damage;
		float currentHp = hp / maxHp;
		healthBar.SetSize(currentHp);
		if (hp <= 0)
		{
			hp = 0;
			Respawn();
		}
		else
		{
			StartCoroutine(Flicker());
		}
	}
	IEnumerator HitDelay()
	{
		yield return new WaitForSeconds(1f);
		if (healing == false)
		{
			canHit = true;
		}
	}
	void OnTriggerStay2D(Collider2D hit)
	{
		if (canHit && hit.gameObject.CompareTag("Enemy"))
		{
			TakeDamage(20);
			canHit = false;
			StartCoroutine(HitDelay());
		}
	}
}