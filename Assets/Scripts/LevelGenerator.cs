/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece>();
	public int counter = 0;

	void Awake()
	{
		instance = this;
	}

	public void Start()
	{
		GenerateInitialPieces();
	}

	// Generate initial pieces of the board
	public void GenerateInitialPieces()
	{
		for (int i = 0; i < 15; i++)
		{
			AddPiece();
		}
	}

	//changed this to generate level pieces based on the players current level
	public void AddPiece()
	{
		int index;
		//level 0
		if (PlayerController.instance.GetLevel() == 0)
			index = 0;
		//level 1 or greater
		else index = Random.Range(1, levelPrefabs.Count - 1);
		//Instantiate copy of random level prefab and store it in piece variable
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[index]);
		piece.transform.SetParent(this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0)
		{
			//first piece
			spawnPosition = levelStartPoint.position;
		}
		else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add(piece);
		counter++;

	}


	public void AddFinish()
	{
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[3]);
		piece.transform.SetParent(this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0)
		{
			//first piece
			spawnPosition = levelStartPoint.position;
		}
		else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add(piece);
		counter++;

	}

	//method to remove previous levels, not working properly
	public void RemoveLevel()
	{
		pieces.Clear();
	}

	//counter method used for counting the number of level pieces added(testign purposes)
	public static int GetCounter()
	{
		return instance.counter;
	}
}