/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	public List<CoinPiece> coinPrefabs = new List<CoinPiece> ();
	public Transform levelStartPoint;
	public List<CoinPiece> pieces = new List<CoinPiece> ();

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		GenerateInitialCoins();
	}


	public void GenerateInitialCoins ()
	{
		for (int i = 0; i < 10; i++) {
			AddCoin ();
		}
	}

	public void AddCoin ()
	{

		//pick the random number
		int randomIndex = Random.Range (0,coinPrefabs.Count);

		//Instantiate copy of random level prefab and store it in piece variable
		CoinPiece piece = (CoinPiece)Instantiate (coinPrefabs [randomIndex]);
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

		CoinPiece oldestPiece = pieces [0];

		pieces.Remove (oldestPiece);
		Destroy (oldestPiece.gameObject);
	}
}
*/