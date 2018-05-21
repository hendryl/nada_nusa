using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	public Text text;

	private AsyncOperation asyncLoad;

	// Use this for initialization
	void Start () {
		StartCoroutine(LoadScene());
	}

	// Update is called once per frame
	void Update () {
		if (asyncLoad != null) {
			text.text = "Loading " + Mathf.FloorToInt(asyncLoad.progress * 100f) + "%";
		}
	}

	IEnumerator LoadScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

		yield return new WaitForSeconds(3);

        asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
		Debug.Log(asyncLoad.ToString());


        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

		SceneManager.UnloadSceneAsync(0);
    }
}
