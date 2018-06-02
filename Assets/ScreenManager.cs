using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameScreen {
	Main,
	Cerita,
	Prologue,
}

public class ScreenManager : MonoBehaviour {

	public static ScreenManager Instance {
		get { return _instance; }
	}
	public GameScreen currentScreen {
		get { return _currentScreen; }
	}
	public Component mainScreen, ceritaScreen, prologueScreen;
	public Image fadeOverlay;
	public Camera mainCamera;

	private static ScreenManager _instance;
	private GameScreen _currentScreen = GameScreen.Main;

	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

		mainCamera.GetComponent<Camera>().orthographicSize = 1600/Screen.width * Screen.height/2;
	}

	// Use this for initialization
	void Start () {
		HideAllScreens();
		ShowScreen(_currentScreen);
	}

	Component GetComponentFromScreen(GameScreen screen) {
		switch (screen) {
			case GameScreen.Main: return mainScreen;
			case GameScreen.Cerita: return ceritaScreen;
			case GameScreen.Prologue: return prologueScreen;
			default: return mainScreen;
		}
	}

	public void SetScreen (GameScreen screen) {
		GameScreen previousScreen = _currentScreen;
		_currentScreen = screen;

		StartCoroutine(Fade(previousScreen, _currentScreen));
	}

	void HideAllScreens () {
		foreach (GameScreen screen in GameScreen.GetValues(typeof(GameScreen)))
		{
			Component c = GetComponentFromScreen(screen);
			c.gameObject.SetActive(false);
		}
	}

	void HideScreen (GameScreen screen) {
		Component c = GetComponentFromScreen(screen);
		c.gameObject.SetActive(false);
	}

	void ShowScreen (GameScreen screen) {
		Component c = GetComponentFromScreen(screen);
		c.gameObject.SetActive(true);
		c.SendMessage("Setup");
	}

	IEnumerator Fade(GameScreen prev, GameScreen cur) {
		fadeOverlay.gameObject.SetActive(true);
		yield return new WaitUntil(() => fadeOverlay.color.a == 1);
		HideScreen(prev);
		ShowScreen(cur);
		yield return new WaitUntil(() => fadeOverlay.color.a == 0);
		fadeOverlay.gameObject.SetActive(false);
	}
}
