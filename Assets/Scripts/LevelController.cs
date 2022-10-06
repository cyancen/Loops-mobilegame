using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {




	public bool isRotatingClockwise;
	public bool isStillRotating;
	public float stageSpeed;
	public float shrinkScale;
	public float rndSpeedIncrement;
	public float rndShrinkIncrement;

	public GameObject currentGameStatObject;
	public GameStats gameStatsScript;
	public GameObject particleGlowObject;




	// Use this for initialization
	void Start () {
		rndSpeedIncrement = Random.Range(2,15);
		rndShrinkIncrement = Random.Range(0.3f,1.1f);
		isStillRotating = true;
		float directionProbability = Random.value;
		if (directionProbability < 0.5f) {
			isRotatingClockwise = true;
		} else {
			isRotatingClockwise = false;
		}

		currentGameStatObject = GameObject.FindGameObjectWithTag("game_stats");
		gameStatsScript = currentGameStatObject.GetComponent<GameStats>();
	
	}
	
	// Update is called once per frame
	void Update () {
		CircletRotation();
		SetStageSpeed();
	}

	//the circle rotation and its shrinking scale
	void CircletRotation () {
		if (isRotatingClockwise == true && isStillRotating == true) {
			this.transform.Rotate(Vector3.back * Time.deltaTime * stageSpeed);
		} else if (isRotatingClockwise == false && isStillRotating == true) {
			this.transform.Rotate(Vector3.forward * Time.deltaTime * stageSpeed);
		}
		this.transform.localScale -= new Vector3 (shrinkScale * Time.deltaTime, shrinkScale * Time.deltaTime, 0);
		if (this.transform.localScale.magnitude <= 1.1f) {
			Destroy(gameObject);
			gameStatsScript.playerScore++;
			
		}
	}

	// makes circle speed rotation as the score gets higher	
	void SetStageSpeed () {
		if (this.transform.localScale.magnitude <= 2f) {
			isStillRotating = false;
			shrinkScale = 5f;
		} else {
			if (gameStatsScript.playerScore >= 10) {
				shrinkScale = 2f + rndShrinkIncrement;
			} else {
				shrinkScale = 2f;
			}
		}
		if (gameStatsScript.playerScore <= 2) {
			stageSpeed = 30;
		} else {
			stageSpeed = gameStatsScript.playerScore * 10;
			if (gameStatsScript.playerScore > 6) {
				stageSpeed = 60 + rndSpeedIncrement;
			}
			if (gameStatsScript.playerScore > 15) {
				stageSpeed = 60 + rndSpeedIncrement + 10;;
			}
			if (gameStatsScript.playerScore > 20) {
				stageSpeed = 60 + rndSpeedIncrement + 13;
			}
		}
	}


}
