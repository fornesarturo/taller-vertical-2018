using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {
	public Transform canvas;
	public Transform Player;
	// private bool paused;
	public Transform[] menuItems;
	private int currentMenuItem;


	void Start () {
		this.currentMenuItem = 0;

	}

	void Update () {
		if (Input.GetButtonDown("Pause"))
			Pause();
		if (canvas.gameObject.activeInHierarchy && Input.GetAxis ("Vertical") == -1) {
			this.currentMenuItem = (this.currentMenuItem + 1) % 3;
			EventSystem.current.SetSelectedGameObject (menuItems[currentMenuItem].gameObject);
		}
		if (canvas.gameObject.activeInHierarchy && Input.GetAxis ("Vertical") == 1) {
			this.currentMenuItem = (this.currentMenuItem - 1 == -1)? 2: this.currentMenuItem - 1;
			EventSystem.current.SetSelectedGameObject (menuItems[currentMenuItem].gameObject);
		}
	}

	public void Pause(){
		if (!canvas.gameObject.activeInHierarchy) {
			canvas.position = Player.GetChild(0).position + Player.GetChild(0).forward;
			canvas.rotation = Player.GetChild (0).rotation;
			EventSystem.current.GetComponent<GvrPointerInputModule>().enabled = false;
			EventSystem.current.GetComponent<StandaloneInputModule>().enabled = true;
			canvas.gameObject.SetActive (true);
			this.currentMenuItem = 0;
			EventSystem.current.SetSelectedGameObject (menuItems[currentMenuItem].gameObject);
			Time.timeScale = 0;
			Player.GetComponent<CharacterController>().enabled = false;
		} else {
			EventSystem.current.GetComponent<StandaloneInputModule>().enabled = false;
			EventSystem.current.GetComponent<GvrPointerInputModule>().enabled = true;
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			Player.GetComponent<CharacterController>().enabled = true;
		}
	}
}
