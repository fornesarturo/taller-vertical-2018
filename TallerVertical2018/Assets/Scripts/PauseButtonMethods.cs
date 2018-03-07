using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseButtonMethods : MonoBehaviour {
	// Use this for initialization
	private bool selecting;
	void Start () {
		selecting = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToCaseFiles() {
		Debug.Log ("Go To Case Files!");
		StartCoroutine ("goToCaseFilesCorroutine");
	}

	public void ReturnToScene() {
		Debug.Log ("Return to Scene!");
		StartCoroutine ("returnToSceneCorroutine");
	}

	public void ExitGame() {
		Debug.Log ("Exit Game!");
		StartCoroutine ("exitCorroutine");
	}

	public void SetGaze(bool gaze) {
		this.selecting = gaze;
		if (!this.selecting) {
			Debug.Log ("STOPPED!");
			StopAllCoroutines ();
		}
	}

	IEnumerator returnToSceneCorroutine() {
		float seconds = 0f;
		while (true) {
			if (seconds < 1f) {
				seconds += 1f;
			} else {
				PlayerPrefs.SetString ("NextSceneToLoad", PlayerPrefs.GetString ("LastVisitedScene"));
				SceneManager.LoadScene ("LoadingScreen", LoadSceneMode.Single);
			}
			yield return new WaitForSecondsRealtime (1f);
		}
	}

	IEnumerator goToCaseFilesCorroutine() {
		float seconds = 0f;
		while (true) {
			if (seconds < 1f) {
				seconds += 1f;
			} else {
				PlayerPrefs.SetString ("NextSceneToLoad", "CaseFileTest");
				PlayerPrefs.SetString ("LastVisitedScene", SceneManager.GetActiveScene().name);
				SceneManager.LoadScene ("LoadingScreen", LoadSceneMode.Single);
			}
			yield return new WaitForSecondsRealtime (1f);
		}
	}
		
	IEnumerator exitCorroutine() {
		Debug.Log ("Started exit corroutine");
		float seconds = 0f;
		while (true) {
			if (seconds < 1f) {
				seconds += 1f;
			} else {
				Application.Quit ();
			}
			yield return new WaitForSecondsRealtime (1f);
		}
	}
}