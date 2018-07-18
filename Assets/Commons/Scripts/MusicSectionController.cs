using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSectionController : MonoBehaviour {
    public Component storageScript, storyController;
    public AudioSource musicPlayer;
    public Sprite[] backgroundImages;
    public Sprite[] musicFlowImages;
    public Canvas background, textBox, flowBackground;
    public Button nextButton, menuButton, closeMenuButton;
    public bool isVertical = false;

    public Image logo;

    LyricStorageInterface storage;

    Canvas bg, flowBg;
    RectTransform bgRect, flowRect;
    Button _nextButton, _menuButton, _closeMenuButton;
    Text _text;
    float bgWidth;
    float bgHeight;
    float currentTime = 0;
    int nextLyric = 0;
    float movement = 0;

    public float FLOW_SPEED_X = 30;
    public float FLOW_SPEED_Y = 4;
    const float FLOW_MAXDISTANCE = 30;

    void Awake () {
        storage = storageScript.GetComponent<LyricStorageInterface>();
        bg = background.GetComponent<Canvas>();
        flowBg = flowBackground.GetComponent<Canvas>();
        bgRect = background.GetComponent<RectTransform>();
        flowRect = flowBackground.GetComponent<RectTransform>();
        _nextButton = nextButton.GetComponent<Button>();
        _menuButton = menuButton.GetComponent<Button>();
        _closeMenuButton = closeMenuButton.GetComponent<Button>();
        _text = textBox.gameObject.GetComponentInChildren<Text>();
	}

	void Start () {
        _menuButton.onClick.AddListener(OnClickMenu);
        _closeMenuButton.onClick.AddListener(OnCloseMenu);

        _nextButton.onClick.AddListener(OnClickNext);
        _nextButton.gameObject.SetActive(false);

        if (isVertical) {
            movement = bgHeight / storage.endTime;
        } else {
            movement = bgWidth / storage.endTime;
        }
	}

    void Update () {
        // move when music is playing
        float time = Time.deltaTime;
        if (musicPlayer.isPlaying && currentTime <= storage.endTime) {
            currentTime += time;

                flowRect.anchoredPosition += new Vector2(FLOW_SPEED_X * time, FLOW_SPEED_Y);

                if (flowRect.anchoredPosition.x > FLOW_MAXDISTANCE ||
                flowRect.anchoredPosition.x < (FLOW_MAXDISTANCE * -1)) {
                    FLOW_SPEED_X *= -1;
                }

                if (flowRect.anchoredPosition.y > FLOW_MAXDISTANCE ||
                flowRect.anchoredPosition.y < (FLOW_MAXDISTANCE * -1)) {
                    FLOW_SPEED_Y *= -1;
                }

            if (isVertical) {
                if (bgHeight > (Mathf.Abs(bgRect.anchoredPosition.y))) {
                    float moveY = time * movement;
                    bgRect.anchoredPosition += new Vector2(0, moveY);
                } else {
                    bgRect.anchoredPosition = new Vector2(0, bgHeight);
                    nextButton.gameObject.SetActive(true);
                }
            } else {
                if (bgWidth > (Mathf.Abs(bgRect.anchoredPosition.x))) {
                    float moveX = time * movement;
                    bgRect.anchoredPosition = bgRect.anchoredPosition - new Vector2(moveX, 0);
                } else {
                    bgRect.anchoredPosition = new Vector2(-bgWidth, 0);
                    nextButton.gameObject.SetActive(true);
                }
            }

            // lyrics updater
            if (nextLyric < storage.lyricModels.Count && currentTime >= storage.lyricModels[nextLyric].startTime) {
                int index = storage.lyricModels[nextLyric].lyricIndex;
                _text.text = storage.lyrics[index];
                nextLyric += 1;
            }
        } else if (currentTime >= storage.endTime) {
            nextButton.gameObject.SetActive(true);
        }
    }

    public void Setup () {
        currentTime = 0;
        nextLyric = 0;

        SetupImages();
        SetupFlow();

        if (PlayerPrefs.GetInt("music", 1) == 0) {
            musicPlayer.mute = true;
        } else {
            musicPlayer.mute = false;
        }

        musicPlayer.Play();
    }

    public void SetupImages () {
        Image lastImage = null;

        for (int i = 0; i < backgroundImages.Length; i++) {
            Sprite currentSprite = backgroundImages[i];

            GameObject NewObj = new GameObject();
            Image NewImage = NewObj.AddComponent<Image>();

            if (i + 1 == backgroundImages.Length) {
                lastImage = NewImage;
            }

            NewImage.sprite = currentSprite;
            RectTransform rect = NewObj.GetComponent<RectTransform>();
            RectTransform parent = bg.GetComponent<RectTransform>();
            rect.SetParent(bg.transform); // Assign the newly created Image GameObject as a Child of the Parent Panel.

            // Set image sizing and anchors
            rect.transform.SetParent(parent);
            rect.localScale = new Vector3(1, 1, 1);
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, 0);
            rect.sizeDelta = Vector2.zero;

            if (isVertical) {
                rect.Translate(new Vector3(0, -i * Screen.height, 0));
            } else {
                rect.Translate(new Vector3(i * Screen.width, 0, 0));
            }

            NewObj.SetActive(true); //Activate the GameObject
        }

        bgWidth = Mathf.Abs(lastImage.GetComponent<RectTransform>().anchoredPosition.x);
        bgHeight = Mathf.Abs(lastImage.GetComponent<RectTransform>().anchoredPosition.y);

        if (logo) {
            logo.transform.SetAsLastSibling();
        }
    }

    public void SetupFlow () {
        Image lastImage = null;

        for (int i = 0; i < musicFlowImages.Length; i++) {
            Sprite currentSprite = musicFlowImages[i];

            GameObject NewObj = new GameObject();
            Image NewImage = NewObj.AddComponent<Image>();

            // hack to fix empty image
            if (isVertical && i == 0) {
                var color = NewImage.color;
                color.a = 0;
                NewImage.color = color;
            }

            if (i + 1 == musicFlowImages.Length) {
                lastImage = NewImage;
            }

            NewImage.sprite = currentSprite;
            RectTransform rect = NewObj.GetComponent<RectTransform>();
            RectTransform parent = flowBg.GetComponent<RectTransform>();
            rect.SetParent(flowBg.transform); // Assign the newly created Image GameObject as a Child of the Parent Panel.

            // Set image sizing and anchors
            rect.transform.SetParent(parent);
            rect.localScale = new Vector3(1, 1, 1);
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, 0);
            rect.sizeDelta = Vector2.zero;

            if (isVertical) {
                rect.Translate(new Vector3(0, -i * Screen.height, 0));
            } else {
                rect.Translate(new Vector3(i * Screen.width, 0, 0));
            }

            NewObj.SetActive(true); //Activate the GameObject
            flowBg.transform.SetAsLastSibling();
        }
    }

    public void OnClickMenu () {
        musicPlayer.Pause();
    }

    public void OnCloseMenu () {
        musicPlayer.UnPause();
    }

    public void OnClickNext () {
        musicPlayer.Stop();
        this.gameObject.SetActive(false);
        storyController.SendMessage("OnChapterMusicFinish");
    }
}