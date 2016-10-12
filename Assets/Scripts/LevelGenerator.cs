using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece> ();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece> ();
	public int counter = 0;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		GenerateInitialPieces ();
	}

	// Generate initial pieces of the board
	public void GenerateInitialPieces ()
	{
		for (int i = 0; i < 6; i++) {
			AddPiece ();
		}
	}

	public void AddPiece ()
	{

		//pick the random number
		int randomIndex = Random.Range (0, levelPrefabs.Count - 1);

		//Instantiate copy of random level prefab and store it in piece variable
		LevelPiece piece = (LevelPiece)Instantiate (levelPrefabs [randomIndex]);
		piece.transform.SetParent (this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0) {
			//first piece
			spawnPosition = levelStartPoint.position;
		} else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces [pieces.Count - 1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add (piece);
		counter++;

	}

	public void AddFinish ()
	{
		LevelPiece piece = (LevelPiece)Instantiate (levelPrefabs [2]);
		piece.transform.SetParent (this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0) {
			//first piece
			spawnPosition = levelStartPoint.position;
		} else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces [pieces.Count - 1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add (piece);
		counter++;

	}

public void RemoveLevel ()
	{
		for (int i = 0; i < pieces.Count; i++) {
			LevelPiece removePiece = pieces [i];
			pieces.Remove (removePiece);
		}
	}



	public static int GetCounter ()
	{
		return instance.counter;
	}
}