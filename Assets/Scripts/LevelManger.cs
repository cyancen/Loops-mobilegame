using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManger : MonoBehaviour {


	public float autoLoadNextSceneTimer;
	public bool gameStarted = false; // starts the game when its true
	public bool gameFinished = false; // is true when game finishes

	

	public GameObject scoreText;
	public GameObject TitleText;
	private GameObject playButton;
	private GameObject restartButton;
	private GameObject infoButton;
	private GameObject musicButton;
	private GameObject highScoreText;



	// Use this for initialization
	void Start () {
		
		gameFinished = false;

		if(autoLoadNextSceneTimer == 0) {
			Debug.Log("Waiting for an event");
		}
		else {
			Invoke("loadNextLevel", autoLoadNextSceneTimer);
		}


		playButton = GameObject.Find("PlayButton");
		restartButton = GameObject.Find("RestartButton");
		infoButton = GameObject.Find("info");
		musicButton = GameObject.Find("MusicButton");
		highScoreText = GameObject.Find("HighScore");

		if (SceneManager.GetActiveScene().buildIndex == 1) {
			AdManager.Instance.ShowBanner();
		}


	}
	
	// Update is called once per frame
	void Update () {
		
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			HideScoreText();
		}

		if (gameFinished == true) {
			Debug.Log("Game is Finished");
		}
	}


	public void loadNextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


	public void PlayGame () {
		gameStarted = true;
		gameFinished = false;
		Debug.Log("Game Started");
		playButton.SetActive(false);
	}

	public void RestartGame () {
		SceneManager.LoadScene("01_Game");
	}

	public void GoToAds () {
		Debug.Log("Open Ad video");
		AdManager.Instance.ShowVideo();
	}

	public void GoToInfo () {
		SceneManager.LoadScene("02_info");
	}






	public void HideScoreText () {
		
		if(gameStarted == false) {
			scoreText.SetActive(false);
			TitleText.SetActive(true);
			infoButton.SetActive(true);
			musicButton.SetActive(true);
		}
		else {
			scoreText.SetActive(true);
			TitleText.SetActive(false);
			infoButton.SetActive(false);
			musicButton.SetActive(false);
		}

		if(gameFinished == true) {
			restartButton.SetActive(true);
			TitleText.SetActive(true);
			highScoreText.SetActive(true);
		}
		else {
			restartButton.SetActive(false);
			highScoreText.SetActive(false);
		}


	}


}
