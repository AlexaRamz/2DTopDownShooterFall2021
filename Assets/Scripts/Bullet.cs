using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject explosion;
	public float knockbackTime;
	IEnumerator DestroyOnTime()
	{
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}
	void Start()
    {
		StartCoroutine(DestroyOnTime());
    }
	void Explosion(Vector3 pos)
	{
		GameObject bullet = Instantiate(explosion, pos, Quaternion.identity);
	}
	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.CompareTag("Enemy"))
		{
			hit.transform.parent.GetComponent<Enemy>().KnockBack(transform.up * 10);
			Explosion(hit.gameObject.transform.position);
			Destroy(gameObject);
		}
		else if (hit.gameObject.CompareTag("Obstacle"))
		{
			Explosion(hit.gameObject.transform.position);
			Destroy(gameObject);
		}
	}
		
	void Update()
    {
        
    }

 
}
