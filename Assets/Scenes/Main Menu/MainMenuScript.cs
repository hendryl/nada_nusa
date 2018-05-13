using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

enum Screens {
	Main,
	Settings,
	Info
}

public class MainMenuScript : MonoBehaviour {
	public Button settingsButton, infoButton, settingsCloseButton, ceritaButton, tantanganButton, koleksiButton;
	public Canvas settingsCanvas, mainMenuCanvas;
	public AudioSource musicPlayer, sfxPlayer;

	Screens currentScreen = Screens.Main;

	private Button _settingsButton, _infoButton,  _settingsCloseButton, _ceritaButton, _tantanganButton, _koleksiButton;
	private Canvas _settings, _mainMenu;
	private AudioSource _music, _sfx;

	int isMusicOn = 1;
	int isSfxOn = 1;

	void Awake () {
		_music = musicPlayer.GetComponent<AudioSource>();
		_sfx = sfxPlayer.GetComponent<AudioSource>();

		_settingsButton = settingsButton.GetComponent<Button>();
		_infoButton = infoButton.GetComponent<Button>();
		_settingsCloseButton = settingsCloseButton.GetComponent<Button>();
		_ceritaButton = ceritaButton.GetComponent<Button>();
		_tantanganButton = tantanganButton.GetComponent<Button>();
		_koleksiButton = koleksiButton.GetComponent<Button>();

		_settings = settingsCanvas.GetComponent<Canvas>();
		_mainMenu = mainMenuCanvas.GetComponent<Canvas>();
	}

	void Start () {
		isMusicOn = PlayerPrefs.GetInt("music", 1);
		isSfxOn = PlayerPrefs.GetInt("sound", 1);

		PlayMusic();

		_settingsButton.onClick.AddListener(OnClickSettings);
		_infoButton.onClick.AddListener(OnClickInfo);
		_settingsCloseButton.onClick.AddListener(OnClickCloseSettings);
		_ceritaButton.onClick.AddListener(onClickCerita);
		_tantanganButton.onClick.AddListener(onClickTantangan);
		_koleksiButton.onClick.AddListener(onClickKoleksi);

		_settings.gameObject.SetActive(false);
	}

	void Update () {
		switch(currentScreen) {
			case Screens.Main: {
				if (!_mainMenu.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(true);
					_settings.gameObject.SetActive(false);
				}
				break;
			}

			case Screens.Info: {

				break;
			}

			case Screens.Settings: {
				if (!_settings.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(false);
					_settings.gameObject.SetActive(true);
				}
				break;
			}
		}
	}

	void PlayButtonSound () {
		if (isSfxOn == 1) {
			_sfx.Play();
		}
	}

	void PlayMusic () {
		if (isMusicOn == 1) {
			_music.Play();
		}
	}

	void onClickCerita () {
		PlayButtonSound();
	}

	void onClickTantangan () {
		PlayButtonSound();
	}

	void onClickKoleksi () {
		PlayButtonSound();
	}

	void OnClickSettings () {
		PlayButtonSound();
		currentScreen = Screens.Settings;
	}

	void OnClickCloseSettings () {
		PlayButtonSound();
		currentScreen = Screens.Main;
	}

	void OnClickInfo () {
		PlayButtonSound();
	}
}
