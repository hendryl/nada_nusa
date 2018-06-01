using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeritaScript : MonoBehaviour {
	public AudioClip clip;
	public Button backButton, leftButton, rightButton, playButton;
	public Image lockImage;
	public RectTransform chapterCanvasT;

	private Button _backButton, _leftButton, _rightButton, _playButton;
	private RectTransform _chapterCanvasT;

	int currentSelection = 0;
	const int X_DISTANCE = 1600;
	const int BASE_X = -800;
	const int MAX_PLAYABLE = 2; // inclusive
	const float SPEED = 8f;
	string[] stories = new string[4] { "prologue", "bungong", "ampar", "cublak" };

	void Awake () {
		_backButton = backButton.GetComponent<Button>();
		_leftButton = leftButton.GetComponent<Button>();
		_rightButton = rightButton.GetComponent<Button>();
		_playButton = playButton.GetComponent<Button>();
		_chapterCanvasT = chapterCanvasT.GetComponent<RectTransform>();
	}

	void Start () {
		_backButton.onClick.AddListener(OnClickBack);
		_leftButton.onClick.AddListener(OnClickLeft);
		_rightButton.onClick.AddListener(OnClickRight);
		_playButton.onClick.AddListener(OnClickPlay);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
		currentSelection = 0;
	}

	// Update is called once per frame
	void Update () {
		// pagination
		if (currentSelection == 0) {
			_leftButton.gameObject.SetActive(false);
			_rightButton.gameObject.SetActive(true);
		} else if (currentSelection == stories.Length - 1) {
			_leftButton.gameObject.SetActive(true);
			_rightButton.gameObject.SetActive(false);
		} else {
			_leftButton.gameObject.SetActive(true);
			_rightButton.gameObject.SetActive(true);
		}

		// chapter frame
		Vector3 targetPosition = new Vector3((currentSelection * X_DISTANCE * -1), 0, 0);
		Vector3 movementNeeded = targetPosition - _chapterCanvasT.localPosition;

		if (Mathf.Abs(movementNeeded.x) < 1f) {
			_chapterCanvasT.localPosition = targetPosition;
		} else {
			_chapterCanvasT.Translate(movementNeeded * SPEED * Time.deltaTime);
		}

		if (movementNeeded == Vector3.zero) {
			if (currentSelection > MAX_PLAYABLE) {
				lockImage.gameObject.SetActive(true);
				playButton.gameObject.SetActive(false);
			} else {
				lockImage.gameObject.SetActive(false);
				playButton.gameObject.SetActive(true);
			}
		} else {
			playButton.gameObject.SetActive(false);
			lockImage.gameObject.SetActive(false);
		}
	}

	void OnClickBack () {
		ScreenManager.Instance.SetScreen(Screen.Main);
	}

	void OnClickLeft () {
		currentSelection = currentSelection - 1 < 0
			? 0
			: currentSelection - 1;
	}

	void OnClickRight () {
		currentSelection = currentSelection + 1 == stories.Length
			? currentSelection
			: currentSelection + 1;
	}

	void OnClickPlay () {
		if (currentSelection == 0) {
			ScreenManager.Instance.SetScreen(Screen.Prologue);
		} else if (currentSelection == 1) {

		} else if (currentSelection == 2) {

		}
	}
}
