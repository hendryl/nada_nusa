using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Screen {
	Main,
	Cerita
}

public class ScreenManager : MonoBehaviour {

	public static ScreenManager Instance {
		get { return _instance; }
	}
	public Screen currentScreen {
		get { return _currentScreen; }
	}
	public Component mainScreen, ceritaScreen;
	public Image fadeOverlay;
	public Animator fadeAnimator;

	private static ScreenManager _instance;
	private Screen _currentScreen = Screen.Main;

	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

	}

	// Use this for initialization
	void Start () {
		ShowScreen(_currentScreen);
	}

	public void SetScreen (Screen screen) {
		Screen previousScreen = _currentScreen;
		_currentScreen = screen;

		StartCoroutine(Fade(previousScreen, _currentScreen));
	}

	void HideAllScreens () {
		mainScreen.gameObject.SetActive(false);
		ceritaScreen.gameObject.SetActive(false);
	}

	void HideScreen (Screen screen) {
		switch (screen) {
			case Screen.Main: mainScreen.gameObject.SetActive(false);break;
			case Screen.Cerita: ceritaScreen.gameObject.SetActive(false);break;
		}
	}

	void ShowScreen (Screen screen) {
		Component c;
		switch (screen) {
			case Screen.Main: c = mainScreen;break;
			case Screen.Cerita: c = ceritaScreen;break;
			default: c = mainScreen;break;
		}

		c.gameObject.SetActive(true);
		c.SendMessage("Setup");
	}

	IEnumerator Fade(Screen prev, Screen cur) {
		fadeOverlay.gameObject.SetActive(true);
		yield return new WaitUntil(() => fadeOverlay.color.a == 1);
		HideScreen(prev);
		ShowScreen(cur);
		yield return new WaitUntil(() => fadeOverlay.color.a == 0);
		fadeOverlay.gameObject.SetActive(false);
	}
}
