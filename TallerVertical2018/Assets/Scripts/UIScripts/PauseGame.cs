using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
	public Transform canvas;
	public Transform Player;

	void Start () {
		Player.gameObject.SetActive (true);
		//Player.GetComponent<CharacterController>().enabled = true;
	}

	void Update () {
		if (Input.GetButtonDown("Pause"))
			Pause();
	}

	public void Pause(){
		if (!canvas.gameObject.activeInHierarchy) {
			canvas.position = Player.GetChild(0).position + Player.GetChild(0).forward;
			canvas.rotation = Player.GetChild (0).rotation;
			canvas.gameObject.SetActive (true);
			Player.GetComponent<CharacterController>().enabled = false;
		} else {
			canvas.gameObject.SetActive (false);
			if (SceneManager.GetActiveScene ().name != "CaseFile") {
				Player.GetComponent<CharacterController>().enabled = true;
			}
		}
	}
}
