/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */

using UnityEngine;
using System.Collections;
// this class I modified from the leavetrigger script, this is attached to the last level piece in a level to call Winner() 
public class FinishLineTrigger : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Debug.Log ("FinishLine");
			PlayerController.instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			PlayerController.instance.Winner ();
		}
	}
}

