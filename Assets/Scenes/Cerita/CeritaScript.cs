using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeritaScript : MonoBehaviour {
	public AudioClip clip;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		AudioController.Instance.SetMusic(clip);
		AudioController.Instance.PlayMusic();
	}

	// Update is called once per frame
	void Update () {

	}
}
