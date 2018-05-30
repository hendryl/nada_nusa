using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	public Text text;
	public Image fadeOverlay;

	private AsyncOperation asyncLoad;

	// Use this for initialization
	void Start () {
		StartCoroutine(LoadScene());
	}

	IEnumerator LoadScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

		yield return new WaitForSeconds(2);

        asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
		asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
			if (asyncLoad.progress < 0.9f)
            {
				text.text = "Loading " + Mathf.FloorToInt(asyncLoad.progress * 100f) + "%";
				yield return null;
			}

			text.text = "Loading 100%";
			yield return new WaitForSeconds(0.5f);
			fadeOverlay.gameObject.SetActive(true);
			yield return new WaitUntil(() => fadeOverlay.color.a == 1);
			asyncLoad.allowSceneActivation = true;
			SceneManager.UnloadSceneAsync(0);
        }


    }
}
