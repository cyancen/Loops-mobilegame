using UnityEngine;
using System.Collections;

public class playerHitBox : MonoBehaviour {


	public float speed;



	// Use this for initialization
	void Start () {
		speed = 360f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.back * Time.deltaTime * speed);
	}


}
