using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this script on every button!
public class ButtonScript : MonoBehaviour {
	private Button c;
	void Start () {
		Button c = this.gameObject.GetComponent<Button>();
		c.onClick.AddListener(OnClick);
	}

	void OnClick () {
		AudioController.Instance.PlayButtonSound();
	}
}
