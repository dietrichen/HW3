﻿using UnityEngine;
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
	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;
	public int collectedCoins = 0;

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
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
		
		}
		if (newGameState == GameState.inGame) {
			//setup Unity scene for inGame state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;

		
		}
		if (newGameState == GameState.gameOver) {
			//setup Unity scene for gameOver state.
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;


		}
		currentGameState = newGameState;
	}

	void Update ()
	{
		if (Input.GetButtonDown ("s")) {
			StartGame ();
		}
	}

	public void CollectedCoin ()
	{
		collectedCoins++;
	}
}
