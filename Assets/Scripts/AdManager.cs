using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour {

	public static AdManager Instance {set;get;}

	public string bannerId;
	public string videoId;

	private void Start () {
		Instance = this;
		DontDestroyOnLoad(gameObject);

		Admob.Instance().initAdmob(bannerId, videoId);
		Admob.Instance().loadInterstitial();
	}
	
	public void ShowBanner () {
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 1);
	}

	public void ShowVideo () {
		if (Admob.Instance().isInterstitialReady()) {
			Admob.Instance().showInterstitial();
		}
	}


}
