using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public float hp;
	public float maxHp = 100f;
	public HealthBar healthBar;
	GameObject main;

	void Start()
	{
		hp = maxHp;
		healthBar.SetSize(hp / maxHp);
		main = transform.parent.gameObject;
	}

	void Update()
	{

	}

	void Die()
	{
		//kill this object
		Destroy(main);
	}
	public void TakeDamage(float damage)
	{
		hp -= damage;
		float currentHp = hp / maxHp;
		healthBar.SetSize(currentHp);
		main.GetComponent<Enemy>().chasing = true; //Enemy chases you when shot
		if (hp <= 0)
		{
			Die();
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			TakeDamage(25);
		}
	}
}
