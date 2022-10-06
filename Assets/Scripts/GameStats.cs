using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStats : MonoBehaviour {


	public int playerScore;
	public int oldScore;
	public Text scoreText;
	public int highScore;
	public Text currentHighScore;

	public GameObject levelManagerHere;
	public LevelManger levelManagerScript;



	// Use this for initialization
	void Start () {
		levelManagerScript = levelManagerHere.GetComponent<LevelManger>();
		highScore = PlayerPrefsManager.GetHighScore();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManagerScript.gameStarted == true) {
			Scored();
		}
		if (levelManagerScript.gameFinished == true) {
			if(playerScore > highScore) {
				PlayerPrefsManager.SetHighScore(playerScore);
			}
			NewHighScore();
		}
	}

	void Scored () {
		scoreText.text = playerScore.ToString();
	}

	void NewHighScore () {
		if (playerScore > highScore) {
			currentHighScore.text = "high score: " + playerScore.ToString();
		} else {
			currentHighScore.text = "high score: " + highScore.ToString();
		} 
	}

}
