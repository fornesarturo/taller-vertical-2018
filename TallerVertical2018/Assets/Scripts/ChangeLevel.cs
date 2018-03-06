using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	// Use this for initialization
	private string sceneToLoad;
	void Start () {
		sceneToLoad = PlayerPrefs.GetString ("NextSceneToLoad");
		StartCoroutine ("LoadNewScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadNewScene() {

		yield return new WaitForSeconds (2f);

		AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);

		yield return async;
	}
}
