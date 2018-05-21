using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	public AudioClip clip;
	public Button settingsButton, infoButton, settingsCloseButton, exitCloseButton, ceritaButton, tantanganButton, koleksiButton;
	public Canvas settingsCanvas, mainMenuCanvas, exitCanvas;

	private enum MainMenuScreens {
		Main,
		Settings,
		Info,
		Exit,
	}

	private MainMenuScreens currentScreen = MainMenuScreens.Main;
	private Button _settingsButton, _infoButton,  _settingsCloseButton, _ceritaButton, _tantanganButton, _koleksiButton, _exitCloseButton;
	private Canvas _settings, _mainMenu, _exit;

	void Awake () {
		_settingsButton = settingsButton.GetComponent<Button>();
		_infoButton = infoButton.GetComponent<Button>();
		_settingsCloseButton = settingsCloseButton.GetComponent<Button>();
		_exitCloseButton = exitCloseButton.GetComponent<Button>();
		_ceritaButton = ceritaButton.GetComponent<Button>();
		_tantanganButton = tantanganButton.GetComponent<Button>();
		_koleksiButton = koleksiButton.GetComponent<Button>();

		_settings = settingsCanvas.GetComponent<Canvas>();
		_mainMenu = mainMenuCanvas.GetComponent<Canvas>();
		_exit = exitCanvas.GetComponent<Canvas>();
	}

	void Start () {
		_settingsButton.onClick.AddListener(OnClickSettings);
		_infoButton.onClick.AddListener(OnClickInfo);
		_settingsCloseButton.onClick.AddListener(OnClickClose);
		_exitCloseButton.onClick.AddListener(OnClickClose);
		_ceritaButton.onClick.AddListener(onClickCerita);
		_tantanganButton.onClick.AddListener(onClickTantangan);
		_koleksiButton.onClick.AddListener(onClickKoleksi);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			currentScreen = MainMenuScreens.Exit;
		}

		switch(currentScreen) {
			case MainMenuScreens.Main: {
				if (!_mainMenu.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(true);
					_settings.gameObject.SetActive(false);
					_exit.gameObject.SetActive(false);
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
					_exit.gameObject.SetActive(false);
				}
				break;
			}

			case MainMenuScreens.Exit: {
				if (!_exit.isActiveAndEnabled) {
					_mainMenu.gameObject.SetActive(false);
					_settings.gameObject.SetActive(false);
					_exit.gameObject.SetActive(true);
				}
				break;
			}
		}
	}

	void onClickCerita () {
		ScreenManager.Instance.SetScreen(Screen.Cerita);
	}

	void onClickTantangan () {
	}

	void onClickKoleksi () {
	}

	void OnClickSettings () {
		currentScreen = MainMenuScreens.Settings;
	}

	void OnClickClose () {
		if (this.isActiveAndEnabled) {
			currentScreen = MainMenuScreens.Main;
		}
	}

	void OnClickInfo () {
	}
}
