using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece> ();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece> ();

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		GenerateInitialPieces ();
	}


	public void GenerateInitialPieces ()
	{
		for (int i = 0; i < 3; i++) {
			AddPiece ();
		}
	}

	public void AddPiece ()
	{

		//pick the random number
		int randomIndex = Random.Range (0, levelPrefabs.Count);

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
	}



	public void RemoveOldestPiece ()
	{

		LevelPiece oldestPiece = pieces [0];

		pieces.Remove (oldestPiece);
		Destroy (oldestPiece.gameObject);
	}
}
