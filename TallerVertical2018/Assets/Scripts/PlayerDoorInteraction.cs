using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoorInteraction : MonoBehaviour {

	private bool colliding;
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		this.controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.controller.collisionFlags == CollisionFlags.Below) {
			this.colliding = false;
		}
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Door") {
			if (!colliding && hit.gameObject.GetComponent<DoorController> ().isGazed) {
				Debug.Log ("Enter to house...");
				PlayerPrefs.SetString ("NextSceneToLoad", hit.gameObject.GetComponent<DoorController>().sceneToLoad);
				SceneManager.LoadScene ("LoadingScreen", LoadSceneMode.Single);
				this.colliding = true;
			}
		}
	}
}
