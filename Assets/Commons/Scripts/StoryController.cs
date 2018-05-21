using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
	public AudioClip clip;
    public Image background;
    public Component storageScript;
    public Button prevButton, nextButton;
    public Canvas textBox;

    StorageInterface storage;
    Button _prevButton, _nextButton;
    Image _bg;
    Button _clickArea;
    Text _text;
    int currentTextIndex = 0;

	void Awake () {
        _bg = background.GetComponent<Image>();
        _text = textBox.gameObject.GetComponentInChildren<Text>();
        _prevButton = prevButton.GetComponent<Button>();
        _nextButton = nextButton.GetComponent<Button>();
        storage = storageScript.GetComponent<StorageInterface>();
	}

	void Start () {
        _prevButton.onClick.AddListener(OnClickPrev);
        _nextButton.onClick.AddListener(OnClickNext);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
        currentTextIndex = 0;
		_prevButton.gameObject.SetActive(false);
        HideBackground();
        SetNewPage();
	}

    void SetNewPage () {
        TextModel model = storage.models[currentTextIndex];

        _bg.sprite = storage.sprites[model.spriteIndex];
        _text.text = storage.texts[model.textIndex];
        AudioController.Instance.PlayVoice(storage.voices[model.voiceIndex]);
    }

	// Update is called once per frame
	void Update () {
		// pagination
	}

    void OnClickNext () {
        currentTextIndex += 1;

		if (currentTextIndex > 0) {
			_prevButton.gameObject.SetActive(true);
		}

        if (currentTextIndex < storage.models.Count) {
            SetNewPage();
        } else {
            // TODO: Show finished modal
        }
    }

	void OnClickPrev () {
		currentTextIndex -= 1;
		SetNewPage();

		if (currentTextIndex == 0) {
			_prevButton.gameObject.SetActive(false);
		} else {
			_prevButton.gameObject.SetActive(true);
		}
	}

	void HideBackground () {
		_bg.sprite = null;
	}
}
