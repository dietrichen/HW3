
using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("dead");
			PlayerController.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			PlayerController.instance.Kill ();
		}
	}
}
