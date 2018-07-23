using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour {
    public AudioClip clip;
    public Button backButton;

    // Use this for initialization
    void Start () {
        backButton.GetComponent<Button>().onClick.AddListener(OnClickBack);
    }

    void Setup () {
        AudioController.Instance.SetMusic(clip);
        AudioController.Instance.PlayMusic();
    }

    void OnClickBack () {
        ScreenManager.Instance.SetScreen(GameScreen.Main);
    }
}
