using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbacktest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   
    }

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Bullet")){

			Rigidbody2D Enemy = gameObject.GetComponent<Rigidbody2D>();
    		if(Enemy != null){
        		Enemy.velocity = other.transform.up * 2;
        		StartCoroutine(knockbackCo(Enemy));
    	}

    }

    }
    private IEnumerator knockbackCo(Rigidbody2D Enemy){
        if(Enemy != null){
            yield return new WaitForSeconds(2f);
            Enemy.velocity = Vector2.zero;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
