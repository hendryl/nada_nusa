using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Screen {
	Main,
	Cerita,
	Prologue,
}

public class ScreenManager : MonoBehaviour {

	public static ScreenManager Instance {
		get { return _instance; }
	}
	public Screen currentScreen {
		get { return _currentScreen; }
	}
	public Component mainScreen, ceritaScreen, prologueScreen;
	public Image fadeOverlay;

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
		HideAllScreens();
		ShowScreen(_currentScreen);
	}

	Component GetComponentFromScreen(Screen screen) {
		switch (screen) {
			case Screen.Main: return mainScreen;
			case Screen.Cerita: return ceritaScreen;
			case Screen.Prologue: return prologueScreen;
			default: return mainScreen;
		}
	}

	public void SetScreen (Screen screen) {
		Screen previousScreen = _currentScreen;
		_currentScreen = screen;

		StartCoroutine(Fade(previousScreen, _currentScreen));
	}

	void HideAllScreens () {
		foreach (Screen screen in Screen.GetValues(typeof(Screen)))
		{
			Component c = GetComponentFromScreen(screen);
			c.gameObject.SetActive(false);
		}
	}

	void HideScreen (Screen screen) {
		Component c = GetComponentFromScreen(screen);
		c.gameObject.SetActive(false);
	}

	void ShowScreen (Screen screen) {
		Component c = GetComponentFromScreen(screen);
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
