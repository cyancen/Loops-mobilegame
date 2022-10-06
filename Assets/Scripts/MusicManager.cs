using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {


	static MusicManager instance = null;

	private AudioSource audioSource;

	private GameObject musicButton;
	private GameObject muteButton;

	private int volumeSwitch;


	public AudioClip bgMusic;


	void Awake () {
		DontDestroyOnLoad(gameObject);
		volumeSwitch = PlayerPrefsManager.GetMusicKey();
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = bgMusic;
		if (volumeSwitch < 1) {
			audioSource.Play();
			audioSource.loop = true;
		} else if (volumeSwitch == 1) {
			audioSource.Stop();
		}
	}


	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
		}
	}

	void Update () {
	}
	

	public void MuteAudio () {
		audioSource.Stop();
	}

	public void PlayAudio() {
		audioSource.Play();
	}
	


}
