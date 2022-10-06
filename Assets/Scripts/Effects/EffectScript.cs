using UnityEngine;
using System.Collections;

public class EffectScript : MonoBehaviour {

	public GameObject levelManagerHere;
	public LevelManger levelManagerScript;

	public GameObject GameStatsObjecHere;
	public GameStats gameStatsScript;


	public int oldScore;
	public int currentScore;


	//prefabs to Instantiate here
	public GameObject ringPrefabHere;
	private GameObject ringClone;
	public GameObject hiddenRingAtEnd;
	private GameObject hiddenRingClone;


	// Use this for initialization
	void Start () {
		levelManagerScript = levelManagerHere.GetComponent<LevelManger>();
		gameStatsScript = GameStatsObjecHere.GetComponent<GameStats>();
		oldScore = 0;
		hiddenRingClone = Instantiate(hiddenRingAtEnd, new Vector3(0,0,30), Quaternion.identity) as GameObject;
		hiddenRingClone.transform.parent = transform;
		hiddenRingClone.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManagerScript.gameStarted == true) {
			currentScore = gameStatsScript.playerScore;
			if (currentScore != oldScore) {
				SpawnRingEffect();
				oldScore = currentScore;
			}
		}

		if (levelManagerScript.gameStarted == true && levelManagerScript.gameFinished == true) {
			hiddenRingClone.SetActive(true);
			hiddenRingClone.transform.Rotate(Vector3.back * Time.deltaTime * 180f);
		}

	}


	public void SpawnRingEffect () {
		ringClone = Instantiate(ringPrefabHere, new Vector3(0,0,30), Quaternion.identity) as GameObject;
		ringClone.transform.parent = transform;
	}




}
