/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */
//from the book
using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
	public bool isCollected;

	void Show ()
	{
		this.GetComponent<SpriteRenderer> ().enabled = true;
		this.GetComponent<CircleCollider2D> ().enabled = true;
		isCollected = false;
	}

	void Hide ()
	{
		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<CircleCollider2D> ().enabled = false;
	}

	void Collect ()
	{
		isCollected = true;
		Hide ();
		GameManager.instance.CollectedCoin ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}



}
