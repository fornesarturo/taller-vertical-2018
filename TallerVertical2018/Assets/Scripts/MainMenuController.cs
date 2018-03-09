using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public Transform Player;
	private bool selected;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		Player.GetComponent<CharacterController>().enabled = false;
		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToCity() {
		StartCoroutine ("goToCityCorroutine");
	}

	public void ExitGame() {
		StartCoroutine ("exitCorroutine");
	}

	public void SetSelected(bool selected) {
		this.selected = selected;
		if (!selected) {
			StopAllCoroutines ();
		}
	}

	IEnumerator goToCityCorroutine() {
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
