using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseButtonMethods : MonoBehaviour {

	private bool selecting;
	public Transform canvas;
	public Transform Player;

	void Start () {
		selecting = false;
	}
	
	// Update is called once per frame
	void Update () { }

	public void GoToCaseFiles() {
		StartCoroutine ("goToCaseFilesCorroutine");
	}

	public void ReturnToScene() {
		StartCoroutine ("returnToSceneCorroutine");
	}

	public void ExitGame() {
		StartCoroutine ("exitCorroutine");
	}

	public void Resume() {
		Debug.Log ("Resume game!");
		StartCoroutine ("resumeCorroutine");
	}

	public void SetGaze(bool gaze) {
		this.selecting = gaze;
		if (!this.selecting) {
			StopAllCoroutines ();
		}
	}

	IEnumerator resumeCorroutine() {
		Debug.Log ("Started resume corroutine");
		float seconds = 0f;
		while (true) {
			if (seconds < 1f) {
				seconds += 1f;
			} else {
				canvas.gameObject.SetActive (false);
				if (SceneManager.GetActiveScene ().name != "CaseFileTest") {
					Player.GetComponent<CharacterController>().enabled = true;
				}
			}
			yield return new WaitForSecondsRealtime (1f);
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
				PlayerPrefs.DeleteAll ();
				Application.Quit ();
			}
			yield return new WaitForSecondsRealtime (1f);
		}
	}
}