using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	public Slider slider;
	// Use this for initialization
	private string sceneToLoad;
	void Start () {
		sceneToLoad = PlayerPrefs.GetString ("NextSceneToLoad");
		slider.value = 0f;
		StartCoroutine ("LoadNewScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadNewScene() {
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
		async.allowSceneActivation = false;
		while (async.progress <= 0.89f) {
			slider.value = async.progress;
			if (async.progress >= 0.88f) {
				slider.value = 1f;
			}
		}
		async.allowSceneActivation = true;
		yield return async;

//		float seconds = 0f;
//		while (seconds <= 10f) {
//			slider.value = seconds / 10f;
//			yield return new WaitForSeconds (1f);
//			seconds += 1f;
//		}
	}
}
