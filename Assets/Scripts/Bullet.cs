using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject explosion;
	void Start()
    {
        
    }
	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit && hit.gameObject.CompareTag("Enemy"))
		{
			GameObject damaging = hit.gameObject;
			damaging.GetComponent<enemyBehavior>().currentHealth -= 1;
			Vector2 enemyPos = new Vector2(damaging.transform.position.x, damaging.transform.position.y);
			GameObject bullet = Instantiate(explosion, enemyPos, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	void Update()
    {
        
    }
}
