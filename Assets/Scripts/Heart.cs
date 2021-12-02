using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
		StartCoroutine(DespawnOnTime());
	}
	IEnumerator Flicker()
	{
		bool off = false;
		for (int i = 0; i < 20; i++)
		{
			yield return new WaitForSeconds(0.15f);
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
		Destroy(gameObject);
	}
	IEnumerator DespawnOnTime()
	{
		yield return new WaitForSeconds(15f);
		StartCoroutine(Flicker());
	}
	void OnTriggerStay2D(Collider2D hit)
	{
		if (hit.gameObject.CompareTag("Player"))
		{
			hit.gameObject.GetComponent<PlayerHealth>().Heal();
			Destroy(gameObject);
		}
	}
}
