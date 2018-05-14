using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeritaScript : MonoBehaviour {
	public AudioClip clip;
	public Button backButton;

	private Button _backButton;

	void Awake () {
		_backButton = backButton.GetComponent<Button>();
	}

	void Start () {
		_backButton.onClick.AddListener(OnClickBack);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnClickBack () {
		ScreenManager.Instance.SetScreen(Screen.Main);
	}
}
