using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum KoleksiTypes {
	Pakaian,
	Rumah,
	Musik,
	Fauna,
	Item
}

public class KoleksiScript : MonoBehaviour {
	public Button pakaianButton, rumahButton, musikButton, faunaButton, backButton, firstButton, secondButton;
	public Canvas contentCanvas, barCanvas, pakaianCanvas, rumahCanvas, musikCanvas, faunaCanvas, itemCanvas;
	public AudioClip clip;
	public Image itemImage;

	Button _pakaianButton, _rumahButton, _musikButton, _faunaButton, _backButton, _firstButton, _secondButton;
	Canvas _contentCanvas, _barCanvas, _pakaianCanvas, _rumahCanvas, _musikCanvas, _faunaCanvas, _itemCanvas;
	Image _itemImage;

	KoleksiTypes currentType;

	int currentItem = -1;

	public List<Sprite> images;

	void Awake () {
		_backButton = backButton.GetComponent<Button>();
		_pakaianButton = pakaianButton.GetComponent<Button>();
		_rumahButton = rumahButton.GetComponent<Button>();
		_musikButton = musikButton.GetComponent<Button>();
		_faunaButton = faunaButton.GetComponent<Button>();
		_firstButton = firstButton.GetComponent<Button>();
		_secondButton = secondButton.GetComponent<Button>();

		_contentCanvas = contentCanvas.GetComponent<Canvas>();
		_barCanvas = barCanvas.GetComponent<Canvas>();
		_pakaianCanvas = pakaianCanvas.GetComponent<Canvas>();
		_rumahCanvas = rumahCanvas.GetComponent<Canvas>();
		_musikCanvas = musikCanvas.GetComponent<Canvas>();
		_faunaCanvas = faunaCanvas.GetComponent<Canvas>();
		_itemCanvas = itemCanvas.GetComponent<Canvas>();
		_itemImage = itemImage.GetComponent<Image>();
	}

	void Start () {
		_backButton.onClick.AddListener(OnClickBack);
		_pakaianButton.onClick.AddListener(OnClickPakaian);
		_rumahButton.onClick.AddListener(OnClickRumah);
		_musikButton.onClick.AddListener(OnClickMusik);
		_faunaButton.onClick.AddListener(OnClickFauna);
		_firstButton.onClick.AddListener(OnClickFirst);
		_secondButton.onClick.AddListener(OnClickSecond);
	}

	void Setup () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
		itemCanvas.gameObject.SetActive(false);
		OnClickPakaian();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnClickBack () {
		if (currentItem >= 0) {
			currentItem = -1;
			itemCanvas.gameObject.SetActive(false);
		} else {
			ScreenManager.Instance.SetScreen(GameScreen.Main);
		}
	}

	void OnClickPakaian () {
		currentType = KoleksiTypes.Pakaian;
		OnClickBottom();
		ChangeContent();
	}
	void OnClickRumah () {
		currentType = KoleksiTypes.Rumah;
		OnClickBottom();
		ChangeContent();
	}
	void OnClickMusik () {
		currentType = KoleksiTypes.Musik;
		OnClickBottom();
		ChangeContent();
	}
	void OnClickFauna () {
		currentType = KoleksiTypes.Fauna;
		OnClickBottom();
		ChangeContent();
	}

	void OnClickBottom () {
		ChangeOpacity(pakaianButton.GetComponent<Image>(), currentType == KoleksiTypes.Pakaian ? 1 : 0);
		ChangeOpacity(rumahButton.GetComponent<Image>(), currentType == KoleksiTypes.Rumah ? 1 : 0);
		ChangeOpacity(musikButton.GetComponent<Image>(), currentType == KoleksiTypes.Musik ? 1 : 0);
		ChangeOpacity(faunaButton.GetComponent<Image>(), currentType == KoleksiTypes.Fauna ? 1 : 0);
	}

	void ChangeOpacity (Image c, float opacity) {
		var color = c.color;
		color.a = opacity;
		c.color = color;
	}

	void ChangeContent () {
		_pakaianCanvas.gameObject.SetActive(currentType == KoleksiTypes.Pakaian);
		_rumahCanvas.gameObject.SetActive(currentType == KoleksiTypes.Rumah);
		_musikCanvas.gameObject.SetActive(currentType == KoleksiTypes.Musik);
		_faunaCanvas.gameObject.SetActive(currentType == KoleksiTypes.Fauna);
	}

	void OnClickFirst () {
		if (currentType == KoleksiTypes.Pakaian) {
			currentItem = 0;
		} else if (currentType == KoleksiTypes.Rumah) {
			currentItem = 2;
		} else if (currentType == KoleksiTypes.Musik) {
			currentItem = 4;
		} else if (currentType == KoleksiTypes.Fauna) {
			currentItem = 6;
		}

		OpenItem();
	}

	void OnClickSecond () {
		if (currentType == KoleksiTypes.Pakaian) {
			currentItem = 1;
		} else if (currentType == KoleksiTypes.Rumah) {
			currentItem = 3;
		} else if (currentType == KoleksiTypes.Musik) {
			currentItem = 5;
		} else if (currentType == KoleksiTypes.Fauna) {
			currentItem = 7;
		}

		OpenItem();
	}

	void OpenItem () {
		if (currentItem >= 0) {
			Sprite image = images[currentItem];

			itemImage.sprite = image;
			itemCanvas.gameObject.SetActive(true);
		}
	}
}
