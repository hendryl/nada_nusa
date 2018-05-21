using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button closeButton, exitButton;

	Button _closeButton, _exitButton;

	// Use this for initialization
	void Awake () {
		_closeButton = closeButton.GetComponent<Button>();
		_exitButton = exitButton.GetComponent<Button>();
	}

	void Start () {
		_closeButton.onClick.AddListener(OnClickClose);
		_exitButton.onClick.AddListener(OnClickExit);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnClickClose () {
		if (this.gameObject.activeInHierarchy) {
			this.gameObject.SetActive(false);
			AudioController.Instance.UnPauseVoice();
		}
	}

	void OnClickExit () {
		ScreenManager.Instance.SetScreen(Screen.Cerita);
		AudioController.Instance.ClearVoice();
		this.gameObject.SetActive(false);
	}
}
