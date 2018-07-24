using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
	public AudioClip clip;
    public Image background;
    public Component storageScript;
    public Button prevButton, nextButton, menuButton, textBoxButton, playButton;
    public Canvas textBox, menuCanvas, chapterCompleteCanvas, songCanvas, overlayCanvas;

    Canvas _songCanvas, _overlayCanvas;
    StorageInterface storage;
    Button _prevButton, _nextButton, _menuButton, _textBoxButton, _playButton;
    RectTransform _textBoxRect;
    Image _bg;
    Button _clickArea;
    Text _text;
    int currentTextIndex = 0;
    bool textBoxIsShown = false;
    bool isChapterMusicPlayed = false;

	const float SPEED = 8f;
    const float textBoxOpenY = 83f;
    const float textBoxCloseY = -83f;

	void Awake () {
        _bg = background.GetComponent<Image>();
        _text = textBox.gameObject.GetComponentInChildren<Text>();
        _textBoxRect = textBox.GetComponent<RectTransform>();
        _prevButton = prevButton.GetComponent<Button>();
        _nextButton = nextButton.GetComponent<Button>();
        _menuButton = menuButton.GetComponent<Button>();
        _textBoxButton = textBoxButton.GetComponent<Button>();
        _songCanvas = songCanvas.GetComponent<Canvas>();
        _overlayCanvas = overlayCanvas.GetComponent<Canvas>();
        _playButton = playButton.GetComponent<Button>();
        storage = storageScript.GetComponent<StorageInterface>();
	}

	void Start () {
        _prevButton.onClick.AddListener(OnClickPrev);
        _nextButton.onClick.AddListener(OnClickNext);
        _menuButton.onClick.AddListener(OnClickMenu);
        _textBoxButton.onClick.AddListener(OnClickTextBoxButton);
        _playButton.onClick.AddListener(OnClickPlay);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
        currentTextIndex = 0;
		_prevButton.gameObject.SetActive(false);
        _songCanvas.gameObject.SetActive(false);
        HideBackground();
        SetNewPage();

        if (textBoxIsShown) {
            SetTextBoxIsShown(false);
        }
	}

    void SetNewPage () {
        TextModel model = storage.models[currentTextIndex];

        if (model.isMusicSection) {
            _bg.sprite = storage.sprites[model.spriteIndex];
            AudioController.Instance.StopVoice();
            AudioController.Instance.StopMusic();
            AudioController.Instance.SetMusic(null);

            if (isChapterMusicPlayed) {
                _text.text = "";
                _overlayCanvas.gameObject.SetActive(true);
            } else {
                this.isChapterMusicPlayed = true;
                _songCanvas.gameObject.SetActive(true);
                _songCanvas.SendMessage("Setup");
            }
        } else {
            _overlayCanvas.gameObject.SetActive(false);
            _bg.sprite = storage.sprites[model.spriteIndex];
            _text.text = storage.texts[model.textIndex];

            if (model.voiceIndex >= 0) {
                AudioController.Instance.PlayVoice(storage.voices[model.voiceIndex]);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        Vector2 targetPosition = textBoxIsShown
            ? new Vector2(0, textBoxOpenY)
            : new Vector2(0, textBoxCloseY);

		Vector2 movementNeeded = targetPosition - _textBoxRect.anchoredPosition;

		if (Mathf.Abs(movementNeeded.x) < 1f) {
			_textBoxRect.anchoredPosition = targetPosition;
		} else {
			_textBoxRect.Translate(movementNeeded * SPEED * Time.deltaTime, Space.World);
		}
	}

    public void OnChapterMusicFinish () {
        OnClickNext();
        AudioController.Instance.SetMusic(clip);
        AudioController.Instance.PlayMusic();
    }

    void OnClickNext () {
        currentTextIndex += 1;

		if (currentTextIndex > 0) {
			_prevButton.gameObject.SetActive(true);
		}

        if (currentTextIndex < storage.models.Count) {
            SetNewPage();
        } else {
            // chapter complete
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

    void OnClickPlay () {
        isChapterMusicPlayed = false;
        _overlayCanvas.gameObject.SetActive(false);
        SetNewPage();
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
