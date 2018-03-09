using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	public Slider slider;
	[SerializeField] private Text textLoading;
	private AsyncOperation async;

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
		yield return null;
		async = SceneManager.LoadSceneAsync(sceneToLoad);
		async.allowSceneActivation = false;

		while (!async.isDone) {

			float progess = Mathf.Clamp01 (async.progress / 0.9f);
			slider.value = progess;
			if (async.progress == 0.9f) {
				textLoading.text = "Press any key to continue";
				if (Input.anyKey) {					
					async.allowSceneActivation = true;	
				}
			}
			yield return null;
		}


//		async = SceneManager.LoadSceneAsync(sceneToLoad);
//		async.allowSceneActivation = false;
//		while (!async.isDone) {
//			slider.value = async.progress;
//			if (async.progress == 0.9f) {
//				slider.value = 1f;
//				async.allowSceneActivation = true;
//			}
//			yield return null;
//		}
//
//		async.allowSceneActivation = true;
		//yield return null;
//		while (async.progress <= 0.89f) {
//			slider.value = async.progress;
//			Debug.Log ("slider1: " + slider.value);
//			Debug.Log ("progress: " + async.progress);
//			if (async.progress >= 0.96f) {
//				slider.value = 1f;
//			}
//			Debug.Log ("slider2: " + slider.value);
//		}
//		async.allowSceneActivation = true;
//		while (!async.isDone) {
//			slider.value = async.progress;
//		}
		//yield return async;

//		float seconds = 0f;
//		while (seconds <= 10f) {
//			slider.value = seconds / 10f;
//			yield return new WaitForSeconds (1f);
//			seconds += 1f;
//		}
	}
}
