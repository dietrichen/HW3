using UnityEngine;
using System.Collections;

public class LeaveTrigger : MonoBehaviour
{


	void OnTriggerEnter2D(Collider2D other)
	{
		if (LevelGenerator.GetCounter() < 10)
		{
			LevelGenerator.instance.AddPiece();
		}
		if (LevelGenerator.GetCounter() == 10)
			LevelGenerator.instance.AddFinish();
	}

}