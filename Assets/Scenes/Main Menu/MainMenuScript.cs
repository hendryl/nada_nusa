using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	public AudioClip clip;
	public Button settingsButton, infoButton, settingsCloseButton, ceritaButton, tantanganButton, koleksiButton;
	public Canvas settingsCanvas, mainMenuCanvas;

	private enum MainMenuScreens {
		Main,
		Settings,
		Info
	}

	private MainMenuScreens currentScreen = MainMenuScreens.Main;
	private Button _settingsButton, _infoButton,  _settingsCloseButton, _ceritaButton, _tantanganButton, _koleksiButton;
	private Canvas _settings, _mainMenu;

	void Awake () {
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
		_settingsButton.onClick.AddListener(OnClickSettings);
		_infoButton.onClick.AddListener(OnClickInfo);
		_settingsCloseButton.onClick.AddListener(OnClickCloseSettings);
		_ceritaButton.onClick.AddListener(onClickCerita);
		_tantanganButton.onClick.AddListener(onClickTantangan);
		_koleksiButton.onClick.AddListener(onClickKoleksi);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
	}

	void Update () {
		switch(currentScreen) {
			case MainMenuScreens.Main: {
				if (!_mainMenu.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(true);
					_settings.gameObject.SetActive(false);
				}
				break;
			}

			case MainMenuScreens.Info: {

				break;
			}

			case MainMenuScreens.Settings: {
				if (!_settings.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(false);
					_settings.gameObject.SetActive(true);
				}
				break;
			}
		}
	}

	void PlayButtonSound () {
		AudioController.Instance.PlayButtonSound();
	}

	void onClickCerita () {
		PlayButtonSound();
		ScreenManager.Instance.SetScreen(Screen.Cerita);
	}

	void onClickTantangan () {
		PlayButtonSound();
	}

	void onClickKoleksi () {
		PlayButtonSound();
	}

	void OnClickSettings () {
		PlayButtonSound();
		currentScreen = MainMenuScreens.Settings;
	}

	void OnClickCloseSettings () {
		PlayButtonSound();
		currentScreen = MainMenuScreens.Main;
	}

	void OnClickInfo () {
		PlayButtonSound();
	}
}
