using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public float jumpForce = 6f;
	public float runningSpeed = 1.5f;
	public Animator animator;
	public float scoreSpeed = 25f;

	private Rigidbody2D rigidBody;
	private Vector3 startingPosition = new Vector3 (0, 0, 0);

	void Awake ()
	{
		instance = this;
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void StartGame ()
	{
		animator.SetBool ("isAlive", true);
		this.transform.position = startingPosition;
	}

	void Update ()
	{
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (Input.GetMouseButtonDown (0)) {
				Jump ();
			}
			if (GetDistance () > scoreSpeed) {
				runningSpeed += .25f;
				scoreSpeed += 25f;
			}
			animator.SetBool ("isGrounded", IsGrounded ());
		}
	}

	void FixedUpdate ()
	{
		if (GameManager.instance.currentGameState == GameState.inGame) {
			if (rigidBody.velocity.x < runningSpeed) {
				rigidBody.velocity = new Vector2 (runningSpeed,
					rigidBody.velocity.y);
			}
		}
	}

	void Jump ()
	{
		if (IsGrounded ()) {
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public LayerMask groundLayer;

	bool IsGrounded ()
	{
		if (Physics2D.Raycast (this.transform.position, Vector2.down, 0.2f,
			    groundLayer.value)) {
			return true;
		} else {
			return	false;
		}
	}

	public void Kill ()
	{
		GameManager.instance.GameOver ();
		animator.SetBool ("isAlive", false);

		if (PlayerPrefs.GetFloat ("highscore", 0) < this.GetDistance ()) {
			PlayerPrefs.SetFloat ("highscore", this.GetDistance ());
		}
	}

	public float GetDistance ()
	{
		float traveledDistance = Vector2.Distance (new Vector2 (startingPosition.x, 0), new Vector2 (this.transform.position.x, 0));
		return traveledDistance;
	}

}
