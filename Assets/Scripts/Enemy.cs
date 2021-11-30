using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public Transform target;

    public float speed;
    public float attackRange;
    public float waitTime;
    public float startWaitTime;

    public bool chasing;
	bool knock;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void FixedUpdate()
    {
		if (knock == false && chasing && target.parent.GetComponent<playerMovement>().canMove)
		{
			Look(target);

			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
			if (Vector2.Distance(transform.position, target.position) <= attackRange)
			{
				Debug.Log("attack");
			}
		}
    }
	IEnumerator KnockDelay()
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		knock = false;
	}
	public void KnockBack(Vector2 vel)
	{
		knock = true;
		gameObject.GetComponent<Rigidbody2D>().velocity = vel;
		StartCoroutine(KnockDelay());
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && knock == false)
        {
            chasing = true;
        }
    }

    private void Look(Transform toLook)
    {
        Vector3 dir = toLook.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
