using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float jumpForce = 6f;
	private Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
			Jump();
		}

	void Jump() 
	{
		rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}


}



