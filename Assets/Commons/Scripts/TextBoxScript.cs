using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxScript : MonoBehaviour {

	private Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = this.gameObject.GetComponentInChildren<Text>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void setText (string newText) {
		textComponent.text = newText;
	}
}
