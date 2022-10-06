using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioOnOff : MonoBehaviour {


	public Sprite[] musicIcons;

	private GameObject musicManager;
	private MusicManager musicManagerScript;

	public bool musicIsPlaying;
	private int musicChecker;

	// Use this for initialization
	void Start () {
		musicChecker = PlayerPrefsManager.GetMusicKey();
		if (musicChecker < 1) {
			musicIsPlaying = true;
		} else {
			musicIsPlaying = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		musicManager = GameObject.Find("MusicManager");
		musicManagerScript = musicManager.GetComponent<MusicManager>();
		
		if (musicIsPlaying == true) {
			gameObject.GetComponent<Button>().onClick.AddListener(() => MusicMute());
			gameObject.GetComponent<Image>().sprite = musicIcons[0];
		}
		if(musicIsPlaying == false) {
			gameObject.GetComponent<Button>().onClick.AddListener(() => MusicPlay());
			gameObject.GetComponent<Image>().sprite = musicIcons[1];
		}

	
	}

	void MusicPlay () {
		musicIsPlaying = true;
		musicManagerScript.PlayAudio();
		PlayerPrefsManager.SetMusicKey(0);
	}

	void MusicMute () {
		musicIsPlaying = false;
		musicManagerScript.MuteAudio();
		PlayerPrefsManager.SetMusicKey(1);
	}

	


}
