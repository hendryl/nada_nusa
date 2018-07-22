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
	public Component storageScript;
	public Button backButton, mulaiButton, firstButton, secondButton, thirdButton;
	public Canvas startCanvas, gameCanvas, winCanvas, loseCanvas;
    public AudioSource musicPlayer;

	ITantanganStorage storage;
	Canvas _startCanvas, _gameCanvas, _winCanvas, _loseCanvas;
	Button _firstButton, _secondButton, _thirdButton;

	void Awake () {
		storage = storageScript.GetComponent<ITantanganStorage>();
		_startCanvas = startCanvas.GetComponent<Canvas>();
		_gameCanvas = gameCanvas.GetComponent<Canvas>();
		_winCanvas = winCanvas.GetComponent<Canvas>();
		_loseCanvas = loseCanvas.GetComponent<Canvas>();
		_firstButton = firstButton.GetComponent<Button>();
		_secondButton = secondButton.GetComponent<Button>();
		_thirdButton = thirdButton.GetComponent<Button>();
	}

	// Use this for initialization
	void Start () {
		storage.Setup();

		backButton.GetComponent<Button>().onClick.AddListener(OnClickBack);
		mulaiButton.GetComponent<Button>().onClick.AddListener(OnClickMulai);

		firstButton.onClick.AddListener(OnClickFirst);
		secondButton.onClick.AddListener(OnClickSecond);
		thirdButton.onClick.AddListener(OnClickThird);
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

	void ShowQuizQuestion () {
		TantanganQuiz quiz = storage.GetNextQuiz();

		// set answers
		_firstButton.GetComponent<Image>().sprite = quiz.choices[0].buttonImage;
		_secondButton.GetComponent<Image>().sprite = quiz.choices[1].buttonImage;
		_thirdButton.GetComponent<Image>().sprite = quiz.choices[2].buttonImage;

		musicPlayer.clip = quiz.question.voice;
		musicPlayer.Play();
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
		ShowQuizQuestion ();
	}

	void OnClickFirst () {
		OnClickAnswer(0);
	}

	void OnClickSecond () {
		OnClickAnswer(1);
	}

	void OnClickThird () {
		OnClickAnswer(2);
	}

	void OnClickAnswer (int id) {
		// TODO: Fix this
		Debug.Log(id);
		ShowQuizQuestion();
	}
}
