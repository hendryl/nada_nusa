using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {


	public static AudioController Instance {
		get { return _instance; }
	}

	public bool isMusicPaused {
		get { return _isMusicPaused; }
	}

	public AudioSource musicPlayer, sfxPlayer;

	private static AudioController _instance;
	private AudioSource _music, _sfx;
	private AudioListener audioListener;

	int isMusicOn = 1;
	int isSfxOn = 1;
	private bool _isMusicPaused = false;

	// Use this for initialization
	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

		_music = musicPlayer.GetComponent<AudioSource>();
		_sfx = sfxPlayer.GetComponent<AudioSource>();
	}

	void Start () {
		audioListener = this.gameObject.AddComponent(typeof(AudioListener)) as AudioListener;
		audioListener.enabled = true;

		isMusicOn = PlayerPrefs.GetInt("music", 1);
		isSfxOn = PlayerPrefs.GetInt("sound", 1);
	}

	public void SetMusic (AudioClip clip) {
		_music.clip = clip;
	}

	public void StopMusic () {
		_music.Stop();
	}

	public void UnPauseMusic () {
		_music.UnPause();
		_isMusicPaused = false;
	}

	public void PauseMusic () {
		_music.Pause();
		_isMusicPaused = true;
	}

	public void PlayMusic () {
		if (isMusicOn == 1) {
			_music.Play();
		}
	}

	public void PlayButtonSound () {
		if (isSfxOn == 1) {
			_sfx.Play();
		}
	}
}
