using UnityEngine;
using System.Collections;

public enum GameState
{
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour
{
	public GameState currentGameState = GameState.menu;
	public static GameManager instance;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		currentGameState = GameState.menu;

	}

	public void StartGame ()
	{
		PlayerController.instance.StartGame ();
		SetGameState (GameState.inGame);
	}

	public void GameOver ()
	{
		SetGameState (GameState.gameOver);
	}

	public void BackToMenu ()
	{
		SetGameState (GameState.menu);
	}

	void SetGameState (GameState newGameState)
	{
		if (newGameState == GameState.menu) {
			//setup Unity scene for menu state
		} else if (newGameState == GameState.inGame) {
			//setup Unity scene for inGame state
		} else if (newGameState == GameState.gameOver) {
			//setup Unity scene for gameOver state
		}
		currentGameState = newGameState;
	}

	void Update ()
	{
		if (Input.GetButtonDown ("s")) {
			StartGame ();
		}
	}
}
