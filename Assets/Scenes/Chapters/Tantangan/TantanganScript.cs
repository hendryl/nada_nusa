using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum TantanganScreen {
	Start,
	Game,
	Win,
	Lose
}

public class TantanganScript : MonoBehaviour {

	public Button backButton, mulaiButton;
	public Canvas startCanvas, gameCanvas, winCanvas, loseCanvas;

	Canvas _startCanvas, _gameCanvas, _winCanvas, _loseCanvas;

	void Awake () {
		_startCanvas = startCanvas.GetComponent<Canvas>();
		_gameCanvas = gameCanvas.GetComponent<Canvas>();
		_winCanvas = winCanvas.GetComponent<Canvas>();
		_loseCanvas = loseCanvas.GetComponent<Canvas>();
	}

	// Use this for initialization
	void Start () {
		backButton.GetComponent<Button>().onClick.AddListener(OnClickBack);
		mulaiButton.GetComponent<Button>().onClick.AddListener(OnClickMulai);
	}

	// Update is called once per frame
	void Update () {

	}

	void Setup () {
		AudioController.Instance.StopMusic();
		SwitchCanvas(TantanganScreen.Start);
	}

	void SwitchCanvas (TantanganScreen s) {
		switch (s) {
			case TantanganScreen.Start: {
				_startCanvas.gameObject.SetActive(true);
				_gameCanvas.gameObject.SetActive(false);
				_winCanvas.gameObject.SetActive(false);
				_loseCanvas.gameObject.SetActive(false);
				break;
			}
			case TantanganScreen.Game: {
				_startCanvas.gameObject.SetActive(false);
				_gameCanvas.gameObject.SetActive(true);
				_winCanvas.gameObject.SetActive(false);
				_loseCanvas.gameObject.SetActive(false);
				break;
			}

			case TantanganScreen.Win: {
				_startCanvas.gameObject.SetActive(false);
				_gameCanvas.gameObject.SetActive(true);
				_winCanvas.gameObject.SetActive(true);
				_loseCanvas.gameObject.SetActive(false);
				break;
			}
			case TantanganScreen.Lose: {
				_startCanvas.gameObject.SetActive(false);
				_gameCanvas.gameObject.SetActive(true);
				_winCanvas.gameObject.SetActive(false);
				_loseCanvas.gameObject.SetActive(true);
				break;
			}
		}
	}

	void OnClickBack () {
		ScreenManager.Instance.SetScreen(GameScreen.Main);
	}

	void OnClickMulai () {
		SwitchCanvas(TantanganScreen.Game);

		// Start a question
		// get a question from questionStorage
		// show and play audio
		// if correct, show win
		// if wrong, show lose
	}
}
