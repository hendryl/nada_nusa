using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
	public AudioClip clip;
    public Image background;
    public Component storageScript;
    public Button prevButton, nextButton, menuButton, textBoxButton;
    public Canvas textBox, menuCanvas, chapterCompleteCanvas;

    StorageInterface storage;
    Button _prevButton, _nextButton, _menuButton, _textBoxButton;
    RectTransform _textBoxRect;
    Image _bg;
    Button _clickArea;
    Text _text;
    int currentTextIndex = 0;
    bool textBoxIsShown = false;

	const float SPEED = 8f;
    const float textBoxOpenY = -320f;
    const float textBoxCloseY = -486f;

	void Awake () {
        _bg = background.GetComponent<Image>();
        _text = textBox.gameObject.GetComponentInChildren<Text>();
        _textBoxRect = textBox.GetComponent<RectTransform>();
        _prevButton = prevButton.GetComponent<Button>();
        _nextButton = nextButton.GetComponent<Button>();
        _menuButton = menuButton.GetComponent<Button>();
        _textBoxButton = textBoxButton.GetComponent<Button>();
        storage = storageScript.GetComponent<StorageInterface>();
	}

	void Start () {
        _prevButton.onClick.AddListener(OnClickPrev);
        _nextButton.onClick.AddListener(OnClickNext);
        _menuButton.onClick.AddListener(OnClickMenu);
        _textBoxButton.onClick.AddListener(OnClickTextBoxButton);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
        currentTextIndex = 0;
		_prevButton.gameObject.SetActive(false);
        HideBackground();
        SetNewPage();

        if (textBoxIsShown) {
            SetTextBoxIsShown(false);
        }
	}

    void SetNewPage () {
        TextModel model = storage.models[currentTextIndex];

        _bg.sprite = storage.sprites[model.spriteIndex];
        _text.text = storage.texts[model.textIndex];
        AudioController.Instance.PlayVoice(storage.voices[model.voiceIndex]);
    }

	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = textBoxIsShown
            ? new Vector3(0, textBoxOpenY, 0)
            : new Vector3(0, textBoxCloseY, 0);

		Vector3 movementNeeded = targetPosition - _textBoxRect.localPosition;

		if (Mathf.Abs(movementNeeded.x) < 1f) {
			_textBoxRect.localPosition = targetPosition;
		} else {
			_textBoxRect.Translate(movementNeeded * SPEED * Time.deltaTime);
		}
	}

    void OnClickNext () {
        currentTextIndex += 1;

		if (currentTextIndex > 0) {
			_prevButton.gameObject.SetActive(true);
		}

        if (currentTextIndex < storage.models.Count) {
            SetNewPage();
        } else {
            currentTextIndex = storage.models.Count - 1;

            AudioController.Instance.StopVoice();

            var chapterCompleteGameObject = chapterCompleteCanvas.gameObject;

            chapterCompleteGameObject.GetComponentInChildren<Text>().text = storage.chapterCompleteString;
            chapterCompleteGameObject.SetActive(true);
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

    void OnClickMenu () {
        if (this.gameObject.activeInHierarchy) {
            menuCanvas.gameObject.SetActive(true);
            AudioController.Instance.PauseVoice();
        }
    }

    void OnClickTextBoxButton () {
        SetTextBoxIsShown(!textBoxIsShown);
    }

    void SetTextBoxIsShown (bool value) {
        Transform rect = _textBoxButton.gameObject.GetComponent<RectTransform>().GetChild(0);
        textBoxIsShown = value;

        rect.Rotate(new Vector3(0, 0, 180));
    }

	void HideBackground () {
		_bg.sprite = null;
	}
}
