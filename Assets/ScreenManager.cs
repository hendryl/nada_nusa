using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private static ScreenManager _instance;
	private Screen _currentScreen = Screen.Main;

	// Use this for initialization
	void Start () {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetScreen (Screen screen) {
		Screen previousScreen = _currentScreen;
		_currentScreen = screen;

		HideScreen(previousScreen);
		ShowScreen(_currentScreen);
	}

	void HideScreen (Screen screen) {
		switch (screen) {
			case Screen.Main: mainScreen.gameObject.SetActive(false);break;
			case Screen.Cerita: ceritaScreen.gameObject.SetActive(false);break;
		}
	}

	void ShowScreen (Screen screen) {
		switch (screen) {
			case Screen.Main: mainScreen.gameObject.SetActive(true);break;
			case Screen.Cerita: ceritaScreen.gameObject.SetActive(true);break;
		}
	}
}
