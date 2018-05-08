using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MainMenuScript : MonoBehaviour {
	public Button settingsButton, infoButton;

	// Use this for initialization
	void Start () {
		Button settings = settingsButton.GetComponent<Button>();
		Button info = infoButton.GetComponent<Button>();

		settings.onClick.AddListener(OnClickSettings);
		info.onClick.AddListener(OnClickInfo);
	}

	void OnClickSettings () {
		Debug.Log("Settings button clicked");
	}

	void OnClickInfo () {
		Debug.Log("Info button clicked");
	}
}
