using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDrop : MonoBehaviour
{
	public float hp;
	public float maxHp = 4;
	public GameObject drop;

	void Start()
    {
		hp = maxHp;
    }
	void SpawnDrop()
	{
		if (Random.value <= 0.33)
		{
			GameObject bullet = Instantiate(drop, transform.position, Quaternion.identity);
		}
	}
	void Die()
	{
		SpawnDrop();
		Destroy(gameObject);
	}
	public void TakeDamage()
	{
		hp -= 1;
		if (hp <= 0)
		{
			Die();
		}
	}
	void Update()
    {
        
    }
}
