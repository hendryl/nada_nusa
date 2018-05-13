using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {
	private float speed = 10f;

	private float onX, offX;
	private Toggle toggle;
	private Transform pin, barOff, barOn;

	void Awake () {
		toggle = GetComponent<Toggle>();
		pin = toggle.transform.Find("Pin");
		barOn = toggle.transform.Find("Bar-On");

		onX = pin.localPosition.x;
		offX = onX - 71;
	}

	void Update () {
		UpdatePosition();
	}

	void UpdatePosition () {
		if (toggle.isOn && Mathf.Abs(pin.localPosition.x - onX) > 0.01) {
			if (pin.localPosition.x > onX) {
				pin.transform.localPosition = new Vector3(onX, pin.localPosition.y, pin.localPosition.z);
			} else {
				Vector3 movement = new Vector3(onX - pin.localPosition.x, 0, 0);
				pin.transform.Translate(movement * speed * Time.deltaTime);
			}
		} else if (!toggle.isOn && Mathf.Abs(pin.localPosition.x - offX) > 0.01) {
			if (pin.localPosition.x < offX) {
				pin.transform.localPosition = new Vector3(offX, pin.localPosition.y, pin.localPosition.z);
			} else {
				Vector3 movement = new Vector3(offX - pin.localPosition.x, 0, 0);
				pin.transform.Translate(movement * speed * Time.deltaTime);
			}
		}
	}

	public void SetInitialPosition () {
		if (toggle.isOn) {
			pin.transform.localPosition = new Vector3(onX, pin.localPosition.y, pin.localPosition.z);
			barOn.gameObject.SetActive(true);
		} else {
			pin.transform.localPosition = new Vector3(offX, pin.localPosition.y, pin.localPosition.z);
			barOn.gameObject.SetActive(false);
		}
	}

	public void OnValueChanged () {
		if (toggle.isOn) {
			barOn.gameObject.SetActive(true);
		} else {
			barOn.gameObject.SetActive(false);
		}
	}
}
