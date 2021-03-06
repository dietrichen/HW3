﻿/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public int level;
	public float jumpForce = 6f;
	public float runningSpeed;
	public float scoreSpeed;
	public Animator animator;

	private Rigidbody2D rigidBody;
	private Vector3 startingPosition;

	void Awake()
	{

		instance = this;
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = this.transform.position;
	}


	public void StartGame()
	{

		PlayerController.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		animator.SetBool("isAlive", true);
		this.transform.position = startingPosition;
		runningSpeed = 5f;
		scoreSpeed = 25;
	}

	//added super jump here, right mouse click
	//added modifiers that can be adjust with level
	void Update()
	{
		if (GameManager.instance.currentGameState == GameState.inGame)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Jump();
			}
			if (Input.GetMouseButtonDown(1))
			{
				SuperJump();
			}
			if (runningSpeed < 20)
			{
				if (GetDistance() > scoreSpeed)
				{
					runningSpeed += 1f + level;
					scoreSpeed += 25f - level;
				}
			}

			animator.SetBool("isGrounded", IsGrounded());
		}
	}

	void FixedUpdate()
	{
		if (GameManager.instance.currentGameState == GameState.inGame)
		{
			if (rigidBody.velocity.x < runningSpeed)
			{
				rigidBody.velocity = new Vector2(runningSpeed,
					rigidBody.velocity.y);
			}
		}
	}

	void Jump()
	{
		if (IsGrounded())
		{
			rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	//superjump, simple method that doubles the jumpforce
	void SuperJump()
	{
		if (IsGrounded())
		{
			rigidBody.AddForce(Vector2.up * jumpForce * 2, ForceMode2D.Impulse);
		}
	}

	public LayerMask groundLayer;

	bool IsGrounded()
	{
		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f,
				groundLayer.value))
		{
			return true;
		}
		else {
			return false;
		}
	}

	public void Kill()
	{
		GameManager.instance.GameOver();
		animator.SetBool("isAlive", false);

		if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
		{
			PlayerPrefs.SetFloat("highscore", this.GetDistance());
		}
	}

	//winner method to call when the level is complete
	public void Winner()
	{
		level++;
		GameManager.instance.LevelComplete();

	}

	public float GetDistance()
	{
		float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
		return traveledDistance;
	}

	//get method so level can be used in other classes
	public int GetLevel()
	{
		return level;
	}

}
