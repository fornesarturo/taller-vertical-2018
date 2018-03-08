using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: MonoBehaviour {

	void Awake() {
		
	}

	void Start () {
		PlayerPrefs.DeleteAll ();
		StartCoroutine ("goToCity");
	}

	void Update () {
		
	}

	IEnumerator goToCity() {
		float seconds = 0f;
		while (true) {
			if (seconds < 1f) {
				seconds += 1f;
			} else {
				PlayerPrefs.SetString ("NextSceneToLoad", "City");
				SceneManager.LoadScene ("LoadingScreen", LoadSceneMode.Single);
			}
			yield return new WaitForSecondsRealtime (1f);
		}
	}
}
