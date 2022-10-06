using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {



	public GameObject levelManagerHere;
	public LevelManger levelManagerScript;
	public GameObject shipPrefab;


	public float rotationSpeed = 1;
	public int pressCounter;
	public int randomValue;


	private float speedVariation;
	private GameObject shipStyle;


	public bool playerHasPressed;
	private bool isGoingClockwise;



	private float maxWidth;
	private float minWidth;
	private float middlePoint;




	// Use this for initialization
	void Start () {
		levelManagerScript = levelManagerHere.GetComponent<LevelManger>();
		SpawnShip();
		playerHasPressed = false;
		randomValue = Random.Range(0,10);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (levelManagerScript.gameStarted == true && levelManagerScript.gameFinished == false) {
			if (playerHasPressed == false) {
				this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed/2);
			}
			PlayerInput();	
		}

		if (levelManagerScript.gameStarted == false) {
			this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed/2);
		}

		if (levelManagerScript.gameStarted == true && levelManagerScript.gameFinished == true) {
			if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2) {
				this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
				isGoingClockwise = true;
			} 
			if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) {
				this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
				isGoingClockwise = false;
			}
			EndGameSpinDirection();
		}

		Debug.Log(middlePoint);

	

	}


	public void PlayerInput () {
		if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2) {
			playerHasPressed = true;
			this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
		}
		if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) {
			playerHasPressed = true;
			this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
		}
	}

	public void EndGameSpinDirection () {
		if (isGoingClockwise == true) {
			this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed/2);
		}
		if (isGoingClockwise == false) {
			this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed/2);
		}
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "loops") {
			Debug.Log("Collision, Lost!");
			levelManagerScript.gameFinished = true;
		}
	}


	public void SpawnShip () {
		shipStyle = Instantiate(shipPrefab, new Vector3(0f,1.25f,0f), Quaternion.identity) as GameObject;
		shipStyle.transform.parent = transform;
	}





}
