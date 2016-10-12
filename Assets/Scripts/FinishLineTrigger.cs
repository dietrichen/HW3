using UnityEngine;
using System.Collections;

public class FinishLineTrigger : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("FinishLine");
			PlayerController.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			PlayerController.instance.Winner ();
			LevelGenerator.instance.RemoveLevel ();
		}
	}
}

