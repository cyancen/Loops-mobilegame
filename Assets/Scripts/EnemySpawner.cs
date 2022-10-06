using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {



	public GameObject LevelManagerHere;
	public LevelManger levelManagerScript;

	public GameObject GameStatsHere;
	public GameStats gameStatsScript;


	public GameObject[] allLoopsInGame;
	public GameObject[] loopPrefabs;

	public int spriteIndex;


	private GameObject circletClone;




	// Use this for initialization
	void Start () {
		levelManagerScript = LevelManagerHere.GetComponent<LevelManger>();
		gameStatsScript = GameStatsHere.GetComponent<GameStats>();
	}
	
	// Update is called once per frame
	void Update () {
		allLoopsInGame = GameObject.FindGameObjectsWithTag("loops");
		if (levelManagerScript.gameFinished == true) {
			foreach (GameObject loops in allLoopsInGame) {
				GameObject.Destroy(loops);
			}
			CancelInvoke();
		}
	}


	void spawnCirclets () {
		if (gameStatsScript.playerScore <= 3) {
			spriteIndex = Random.Range(0,3);
		}
		if (gameStatsScript.playerScore > 4) {
			spriteIndex = Random.Range(0,7);
		}
		circletClone = Instantiate(loopPrefabs[spriteIndex], new Vector3(0,0,25), Quaternion.identity) as GameObject;
		circletClone.transform.parent = transform;
	}

	public void StartSpawning () {
		InvokeRepeating("spawnCirclets" , 0.5f, 1.5f);
	}




}
