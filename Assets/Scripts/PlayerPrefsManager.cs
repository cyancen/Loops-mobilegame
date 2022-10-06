using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {


	const string High_Score_Key = "High_Score";

	const string Music_Key = "music_key";


	public static void SetHighScore (int score) {
		PlayerPrefs.SetInt(High_Score_Key, score);
	}

	public static int GetHighScore () {
		return PlayerPrefs.GetInt(High_Score_Key);
	}

	public static void SetMusicKey (int volume) {
		PlayerPrefs.SetInt(Music_Key, volume);
	}

	public static int GetMusicKey () {
		return PlayerPrefs.GetInt(Music_Key);
	}




}
