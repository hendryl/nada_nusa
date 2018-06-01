using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this script on every button!
public class ChapterCompleteController : MonoBehaviour {
	public Button completeButton, closeButton;
	void Start () {
		completeButton.GetComponent<Button>().onClick.AddListener(OnClickComplete);
        closeButton.GetComponent<Button>().onClick.AddListener(OnClickClose);
	}

	void OnClickComplete () {
        ScreenManager.Instance.SetScreen(Screen.Cerita);
        this.gameObject.SetActive(false);
	}

    void OnClickClose () {
        this.gameObject.SetActive(false);
    }
}
