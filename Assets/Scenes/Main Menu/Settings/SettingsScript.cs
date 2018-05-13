using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

	public Toggle soundToggleG, musicToggleG, voiceToggleG;
	public AudioSource audioTester, musicPlayer;

	public Canvas settings;

	private Toggle soundToggle, musicToggle, voiceToggle;
	private AudioSource _audioTester, _musicPlayer;
	private Canvas _settings;

	private bool isMusicPaused = false;

	// Use this for initialization
	void Awake () {
		soundToggle = soundToggleG.GetComponent<Toggle>();
		musicToggle = musicToggleG.GetComponent<Toggle>();
		voiceToggle = voiceToggleG.GetComponent<Toggle>();
		_audioTester = audioTester.GetComponent<AudioSource>();
		_musicPlayer = musicPlayer.GetComponent<AudioSource>();
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
			_audioTester.Play();
			PlayerPrefs.SetInt("sound", 1);
		} else {
			PlayerPrefs.SetInt("sound", 0);
		}
	}

	void OnChangeMusic (bool newValue) {
		if (newValue) {
			PlayerPrefs.SetInt("music", 1);

			if (isMusicPaused && _musicPlayer) {
				_musicPlayer.UnPause();
				isMusicPaused = false;
			} else if (_musicPlayer) {
				_musicPlayer.Play();
			}
		} else {
			PlayerPrefs.SetInt("music", 0);

			if (_musicPlayer) {
				_musicPlayer.Pause();
			}

			isMusicPaused = true;
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
