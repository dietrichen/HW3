/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */

using UnityEngine;
using System.Collections;
//added a counter to know when to generate the finish line
public class LeaveTrigger : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (LevelGenerator.GetCounter() < 15)
		{
			LevelGenerator.instance.AddPiece();
			Debug.Log(LevelGenerator.GetCounter().ToString());
		}
		if(LevelGenerator.GetCounter() == 15)
			LevelGenerator.instance.AddFinish();
	}

}