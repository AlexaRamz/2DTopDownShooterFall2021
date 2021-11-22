using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    public float hp;
    public float maxHp;
    public HealthBar healthBar;
    
    // Use this for initialization
    void Start()
    {
		healthBar.SetSize(hp / maxHp);
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void TakeDamage(float damage)
    {
        hp -= damage;
        float currentHp = hp / maxHp;
        healthBar.SetSize(currentHp);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AAAAA");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("why");
            TakeDamage(50);
        }
    }

}
