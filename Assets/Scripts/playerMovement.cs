using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[Header("Player Variables")]
	public float playerX = 0; //player position x
	public float playerY = 0; //player position y
	public float moveSpeed = 15.0f; //speed of the player
	public bool canMove;

	public float mouseAngle = 0; //the angle for the player to face (in Degrees)
	public float rotationSpeed = 5.0f; //the speed to rotate the character
	private Vector2 mouseDirection; //where the mouse is in relation to the player
	private Quaternion rotator; //how much we need to rotate

	Transform plr;

	void Start()
	{
		canMove = true;
		plr = transform.Find("PlayerBall");
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove)
		{
			if (Input.GetKeyDown("space"))
			{
				moveSpeed = moveSpeed * 50;
			}
			//player moves up or down
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				playerY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
				transform.Translate(new Vector3(0.0f, playerY, 0.0f));
			}
			//player moves left or right
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				playerX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
				transform.Translate(new Vector3(playerX, 0.0f, 0.0f));
			}
			moveSpeed = 15.0f;

			mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - plr.position;
			mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
			rotator = Quaternion.AngleAxis(mouseAngle, Vector3.forward);
			plr.rotation = Quaternion.Slerp(plr.rotation, rotator, rotationSpeed * Time.deltaTime);
		}
	}
}