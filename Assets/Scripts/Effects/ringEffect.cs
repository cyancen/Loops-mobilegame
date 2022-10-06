using UnityEngine;
using System.Collections;

public class ringEffect : MonoBehaviour {


	public float lifeTimer;
	public int rndRotateSpd;


	// Use this for initialization
	void Start () {
		lifeTimer = 0.3f;
		rndRotateSpd = Random.Range(360,720);
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0) {
			Destroy(gameObject);
		}
		this.transform.Rotate(Vector3.back * Time.deltaTime * rndRotateSpd);
	}
}
