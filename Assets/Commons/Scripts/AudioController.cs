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

	public bool isVoicePaused {
		get { return _isVoicePaused; }
	}

	public AudioSource musicPlayer, sfxPlayer, voicePlayer;

	private static AudioController _instance;
	private AudioSource _music, _sfx, _voice;
	private AudioListener audioListener;

	bool isMusicOn {
		get {
			return PlayerPrefs.GetInt("music", 1) == 1;
		}
	}

	bool isSfxOn {
		get {
			return PlayerPrefs.GetInt("sound", 1) == 1;
		}
	}

	bool isVoiceOn {
		get {
			return PlayerPrefs.GetInt("voice", 1) == 1;
		}
	}

	private bool _isMusicPaused = false, _isVoicePaused = false;

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
		_voice = voicePlayer.GetComponent<AudioSource>();
	}

	void Start () {
		audioListener = this.gameObject.AddComponent(typeof(AudioListener)) as AudioListener;
		audioListener.enabled = true;
	}

	public void SetMusic (AudioClip clip) {
		_music.clip = clip;
	}

	public void StopMusic () {
		_music.Stop();
	}

	public void UnPauseMusic () {
		if (_isMusicPaused && isMusicOn) {
			_music.UnPause();
			_isMusicPaused = false;
		}
	}

	public void PauseMusic () {
		if (_music.isPlaying) {
			_music.Pause();
			_isMusicPaused = true;
		}
	}

	public void PlayMusic () {
		if (isMusicOn ) {
			_music.Play();
		}
	}

	public void PlayButtonSound () {
		if (isSfxOn) {
			_sfx.Play();
		}
	}

	public void PlayVoice (AudioClip v) {
		if (isVoiceOn) {
			_voice.clip = v;
			_voice.Play();
		}
	}

	public void PauseVoice () {
		if (_voice.isPlaying) {
			_voice.Pause();
			_isVoicePaused = true;
		}
	}

	public void UnPauseVoice () {
		if (_isVoicePaused && isVoiceOn) {
			_voice.UnPause();
			_isVoicePaused = false;
		}
	}

	public void StopVoice () {
		if (_voice.isPlaying) {
			_voice.Stop();
		}
	}

	public void ClearVoice () {
		_voice.clip = null;
	}
}
