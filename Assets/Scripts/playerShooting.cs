using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour {
	[Header("Shooting Number Variables")]
	public float shootingDistance = 100.0f; //how far the bullet should travel (detect enemy)
	public Transform firingPoint; //Where the bullet will travel/check from (realistic gun)
	private Vector2 mousePosition; //position of mouse
	private Vector2 firingOrigin; //the (x,y) coordinates of the firingpoint gameObject
	private RaycastHit2D hit; //the line the bullet will follow
	public int maxAmmo = 6;
	public int currentAmmo;

	public GameObject projectile;
	public float bulletSpeed = 15.0f;
	public Camera cam;
	Vector3 originalPos;

	public float reloadTime = 1.0f;

	private bool shake;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		Reload();
	}
	
	IEnumerator ReloadDelay()
	{
		yield return new WaitForSeconds(reloadTime);
		currentAmmo = maxAmmo;
	}
	void Reload()
	{
		StartCoroutine(ReloadDelay());
	}
	IEnumerator StopShake(float duration)
	{
		yield return new WaitForSeconds(duration);
		cam.transform.localPosition = originalPos;
		shake = false;
	}
	void Fire()
	{
		if (gameObject.GetComponent<playerMovement>().canMove)
		{
			if (currentAmmo == 0)
			{
				Reload();
			}
			else
			{
				firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);
				//mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
				//hit = Physics2D.Raycast(firingOrigin, mousePosition - firingOrigin, shootingDistance);

				GameObject bullet = Instantiate(projectile, firingOrigin, firingPoint.rotation);
				bullet.GetComponent<Rigidbody2D>().velocity = firingPoint.up * bulletSpeed;
				
				originalPos = cam.transform.localPosition;
				shake = true;
				StartCoroutine(StopShake(0.3f));

				currentAmmo -= 1;
			}
		}
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Fire();
		}
		if (shake)
		{
			float magnitude = 0.05f;

			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			cam.transform.localPosition = new Vector3(x, y, originalPos.z);
		}
	}

}
