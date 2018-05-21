using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour {

	public Button exitButton;

	private Button _exitButton;

	// Use this for initialization
	void Awake () {
		_exitButton = exitButton.GetComponent<Button>();
	}

	void Start () {
		_exitButton.onClick.AddListener(OnClickExit);
	}

	void OnClickExit () {
		Application.Quit();
	}
}
