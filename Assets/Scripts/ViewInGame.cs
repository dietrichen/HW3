using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour
{

	public Text scoreLabel;
	public Text coinLabel;
	public Text highScoreLabel;

	void Update ()
	{
		if (GameManager.instance.currentGameState == GameState.inGame) {
			scoreLabel.text = PlayerController.instance.GetDistance ().ToString ("f0");
			coinLabel.text = GameManager.instance.collectedCoins.ToString ();
			highScoreLabel.text = PlayerPrefs.GetFloat ("highscore", 0).ToString ("f0");
		}
	}
}