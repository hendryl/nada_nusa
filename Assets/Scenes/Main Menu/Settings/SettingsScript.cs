using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

	public Toggle soundToggleG, musicToggleG, voiceToggleG;

	public Canvas settings;

	private Toggle soundToggle, musicToggle, voiceToggle;
	private Canvas _settings;

	// Use this for initialization
	void Awake () {
		soundToggle = soundToggleG.GetComponent<Toggle>();
		musicToggle = musicToggleG.GetComponent<Toggle>();
		voiceToggle = voiceToggleG.GetComponent<Toggle>();
		_settings = settings.GetComponent<Canvas>();
	}

	void Start () {
		_settings.gameObject.SetActive(true);
		// set toggles to user preferences
		if (PlayerPrefs.GetInt("sound", 1) == 0) {
			soundToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("music", 1) == 0) {
			musicToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("voice", 1) == 0) {
			voiceToggle.isOn = false;
		}

		soundToggle.gameObject.SendMessage("SetInitialPosition");
		musicToggleG.gameObject.SendMessage("SetInitialPosition");
		voiceToggle.gameObject.SendMessage("SetInitialPosition");
		_settings.gameObject.SetActive(false);

		// these need to be done after toggling sound to prevent
		// onchange* from being called
		soundToggle.onValueChanged.AddListener(OnChangeSound);
		musicToggle.onValueChanged.AddListener(OnChangeMusic);
		voiceToggle.onValueChanged.AddListener(OnChangeVoice);
	}

	void OnChangeSound (bool newValue) {
		if (newValue) {
			PlayerPrefs.SetInt("sound", 1);
			AudioController.Instance.PlayButtonSound();
		} else {
			PlayerPrefs.SetInt("sound", 0);
		}
	}

	void OnChangeMusic (bool newValue) {
		AudioController controller = AudioController.Instance;

		if (newValue) {
			PlayerPrefs.SetInt("music", 1);

			if (controller.isMusicPaused) {
				controller.UnPauseMusic();
			} else {
				controller.PlayMusic();
			}
		} else {
			PlayerPrefs.SetInt("music", 0);
			controller.PauseMusic();
		}
	}

	void OnChangeVoice (bool newValue) {
		if (newValue) {
			PlayerPrefs.SetInt("voice", 1);
		} else {
			PlayerPrefs.SetInt("voice", 0);
		}
	}
}
