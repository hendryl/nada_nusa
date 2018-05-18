using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueScript : MonoBehaviour {
	public AudioClip clip;
    public Canvas background;
    public Button clickArea;

    Canvas _bg;
    Button _clickArea;

    string[] parts = new string[] {
        "wow",
        "super wow",
    };
    int currentImageIndex = 0;
    const int IMAGE_COUNT = 6;

	void Awake () {
        _bg = background.GetComponent<Canvas>();
        _clickArea = clickArea.GetComponent<Button>();
	}

	void Start () {
        _clickArea.onClick.AddListener(OnClickArea);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
        currentImageIndex = 0;
        HideAllBackgrounds();
        ShowBackground(currentImageIndex);
	}

	// Update is called once per frame
	void Update () {
		// pagination

	}

    void OnClickArea () {
        int prev = currentImageIndex;
        currentImageIndex += 1;

        if (currentImageIndex == IMAGE_COUNT) {
            ScreenManager.Instance.SetScreen(Screen.Cerita);
            return;
        }

        ShowBackground(currentImageIndex);
        HideBackground(prev);
    }

    void ShowBackground(int index) {
        _bg.transform.Find(index.ToString()).gameObject.SetActive(true);
    }

    void HideBackground (int index) {
        _bg.transform.Find(index.ToString()).gameObject.SetActive(false);
    }

    void HideAllBackgrounds () {
        for (int i = 0; i < IMAGE_COUNT; i++) {
            HideBackground(i);
        }
    }
}
