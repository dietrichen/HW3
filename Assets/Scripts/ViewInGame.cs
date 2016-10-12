/*Eugene Dietrich
 * CSC496
 * HW3
 * 10/11/2016
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//per the book
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